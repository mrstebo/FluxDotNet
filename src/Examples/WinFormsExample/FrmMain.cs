using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FluxDotNet;
using WinFormsExample.Actions;
using WinFormsExample.Enums;
using WinFormsExample.Stores;

namespace WinFormsExample
{
    public partial class FrmMain : Form, IFluxViewFor<TodoStore>
    {
        private volatile bool _isUpdating;

        public FrmMain()
        {
            InitializeComponent();

            Flux.Dispatcher = new AsyncDispatcher();
            Flux.StoreResolver.Register(new TodoStore());

            this.OnChange(store =>
            {
                _isUpdating = true;

                lstTodos.Items.Clear();
                lstTodos.Items.AddRange(store.Todos
                    .OrderBy(x => x.CreatedAt)
                    .Select(x => new ListViewItem(new[]
                    {
                        x.Id.ToString(CultureInfo.InvariantCulture),
                        x.Description
                    })
                    {
                        Tag = x.Id,
                        Checked = x.IsComplete
                    })
                    .ToArray());

                lblItemsLeft.Text = string.Format("{0} item(s) left", store.TodosLeftToComplete);

                btnFilterAll.Enabled = store.ActiveFilter != TodoFilters.All;
                btnFilterActive.Enabled = store.ActiveFilter != TodoFilters.Active;
                btnFilterCompleted.Enabled = store.ActiveFilter != TodoFilters.Complete;

                _isUpdating = false;
            });

            Load += (x, y) => this.Dispatch(new GetAllTodosAction());

            lstTodos.ItemCheck += (x, y) =>
            {
                // Required so we don't end up dispatching again 
                // when changing the check state of an inserted item
                if (_isUpdating)
                    return;

                this.Dispatch(new UpdateTodoAction
                {
                    TodoId = (long) ((ListView) x).Items[y.Index].Tag,
                    Completed = y.NewValue == CheckState.Checked
                });
            };
            txtNewTodo.KeyDown += (x, y) =>
            {
                if (y.KeyCode == Keys.Return)
                {
                    this.Dispatch(new CreateTodoAction {Description = txtNewTodo.Text});

                    txtNewTodo.Text = string.Empty;
                }
            };
            btnAdd.Click += (x, y) =>
            {
                this.Dispatch(new CreateTodoAction {Description = txtNewTodo.Text});

                txtNewTodo.Text = string.Empty;
            };
            btnFilterAll.Click += (x, y) => this.Dispatch(new GetAllTodosAction());
            btnFilterActive.Click += (x, y) => this.Dispatch(new GetActiveTodosAction());
            btnFilterCompleted.Click += (x, y) => this.Dispatch(new GetCompletedTodosAction());
            btnClearCompleted.Click += (x, y) => this.Dispatch(new ClearCompletedTodosAction());
        }
    }
}
