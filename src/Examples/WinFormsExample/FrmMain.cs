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
        public FrmMain()
        {
            InitializeComponent();

            this.OnChange(store =>
            {
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

                btnFilterAll.Enabled = store.ActiveFilter != TodoFilters.All;
                btnFilterActive.Enabled = store.ActiveFilter != TodoFilters.Active;
                btnFilterAll.Enabled = store.ActiveFilter != TodoFilters.Complete;
            });

            Load += (x, y) => this.Dispatch(new GetAllTodosAction());

            // Need to make sure we are not dispatching so we don't get a stack overflow when
            // setting the check state when adding todos from the store to the list view.
            //lstTodos.ItemCheck += (x, y) => this.Dispatch(new UpdateTodoAction
            //{
            //    TodoId = (long) ((ListView) x).Items[y.Index].Tag,
            //    Completed = y.NewValue == CheckState.Checked
            //});
            btnAdd.Click += (x, y) =>
            {
                this.Dispatch(new CreateTodoAction {Description = txtNewTodo.Text});

                txtNewTodo.Text = string.Empty;
            };
            btnFilterAll.Click += (x, y) => this.Dispatch(new GetAllTodosAction());
            btnFilterActive.Click += (x, y) => this.Dispatch(new GetActiveTodosAction());
            btnFilterCompleted.Click += (x, y) => this.Dispatch(new GetCompletedTodosAction());
        }
    }
}
