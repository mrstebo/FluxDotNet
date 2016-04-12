using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FluxDotNet;
using WinFormsExample.Actions;
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
                    .Select(x => new ListViewItem(new[]
                    {
                        x.Id.ToString(CultureInfo.InvariantCulture),
                        x.Description
                    })).ToArray());
            });

            btnAdd.Click += (x, y) =>
            {
                this.Dispatch(new CreateTodoAction {Description = txtNewTodo.Text});

                txtNewTodo.Text = string.Empty;
            };
        }
    }
}
