using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using OnlineShop.Application;
using OnlineShop.Core;
using OnlineShop.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShop.Web.admin
{
    public partial class ViewOrders : System.Web.UI.Page
    {
        // Método que se ejecuta cuando la página se carga
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllOrders();
            }
        }

        // Método para cargar todas las órdenes
        public void LoadAllOrders()
        {
            try
            {
                // Cargo el contexto de datos de Order
                ApplicationDbContext context = new ApplicationDbContext();
                OrderManager orderManager = new OrderManager(context);

                // Obtengo el estado seleccionado del DropDownList
                string selectedStatus = ddlOrderStatus.SelectedValue;

                List<Order> orders; // Creo la variable orders que es una lista de objetos de Order

                // Compruebo si tengo en el DDL un estado seleccionado
                if (string.IsNullOrEmpty(selectedStatus))
                {
                    // Si no tengo estado seleccionado -> Cargo TODAS las ordenes de la usuarios en la variable orders, ordenadas por fecha y luego por estado
                    orders = orderManager.GetAll().OrderByDescending(p => p.DateOrder).ThenBy(p => p.Status).ToList();
                    //Vacio el gv de detalles, por si se hubiera quedado construido de un estado anterior
                    gvOrderDetails.DataSource = null;
                    gvOrderDetails.DataBind();
                }
                else
                {
                    // Si tengo estado seleccionado -> Cargo las ordenes del ESTADO SELECCIONADO, ordenadas por fecha y luego por estado
                    orders = orderManager.GetAll().Where(o => o.Status.ToString() == selectedStatus).OrderByDescending(p => p.DateOrder).ThenBy(p => p.Status).ToList();
                    gvOrderDetails.DataSource = null;
                    gvOrderDetails.DataBind();
                }

                // Compruebo si hay ordenes
                if (orders != null && orders.Count > 0)
                {
                    // Si hay ordenes, creo el GV con la variable orders que he construido en el if anterior
                    gvOrderByUser.DataSource = orders;
                    gvOrderByUser.DataBind();
                    lblOrders.Visible = false; // Hago invisible esta etiqueta por si se hubiea quedado activada de una consulta anterior
                }
                else
                {
                    // Si no hay ordenes, vacio el GV y muestro aviso en la label
                    gvOrderByUser.DataSource = null;
                    gvOrderByUser.DataBind();
                    lblOrders.Text = "No hay pedidos para el estado seleccionado";
                    lblOrders.Visible = true;
                    lblOrders.CssClass = "alert alert-secondary";
                }
            }
            catch (Exception ex)
            {   //Gestion de errores
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al cargar las órdenes",
                    IsValid = false
                };
                Page.Validators.Add(err);
            }
        }

        // Método que se ejecuta cuando se cambia la selección en el DDL de estados
        public void ddlOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAllOrders();
          
        }

        // Método que se ejecuta cuando se cambia la página en el GridView
        public void gvOrderByUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrderByUser.PageIndex = e.NewPageIndex;
            LoadAllOrders();
        }

        // Métdod que se ejecuta cuando se pulsa una de las dos acciones de cada linea del GV
        public void gvOrderByUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details") //Si pulso en detalles, construyo el gv de detalle pasandole la ID
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                LoadOrderDetails(orderId);
            }
            else if (e.CommandName == "Change") //Si pulso en change, llamo al método que cambia los estados
            {
                int orderId = Convert.ToInt32(e.CommandArgument);
                ChangeOrderStatus(orderId);
                LoadAllOrders();
            }
        }

        // Método para cargar los detalles de un pedido
        public void LoadOrderDetails(int orderId)
        {
            //Genero contexto y cargo el detalle por la ID del pedido
            ApplicationDbContext context = new ApplicationDbContext();
            OrderDetailManager orderDetailManager = new OrderDetailManager(context);
            var orderDetails = orderDetailManager.GetAll().Where(od => od.OrderId == orderId).ToList();

            gvOrderDetails.DataSource = orderDetails;
            gvOrderDetails.DataBind();
        }

        // Método para cambiar el estado de un pedido
        public void ChangeOrderStatus(int orderId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderManager orderManager = new OrderManager(context);
            var order = orderManager.GetById(orderId);

            if (order != null)
            {
                //los estado del pedido pasan por pendiente->en preparacion->enviado->entregado->cancelado
                //genero el estado cancelado por si el admin quiere cancelar una orden por algun motivo
                switch (order.Status)
                {
                    case OrderStatus.Pending:
                        order.Status = OrderStatus.InPreparation;
                        break;
                    case OrderStatus.InPreparation:
                        order.Status = OrderStatus.Shipping;
                        break;
                    case OrderStatus.Shipping:
                        order.Status = OrderStatus.Delivered;
                        break;
                    case OrderStatus.Delivered:
                        order.Status = OrderStatus.Cancelled;
                        break;
                    case OrderStatus.Cancelled:
                        order.Status = OrderStatus.Pending;
                        break;
                }

                orderManager.Update(order);
                context.SaveChanges();
            }
        }

        // Evento que se ejecuta cuando se pulsa "Ir al producto" en el GridView de detalles de orden
        // Reenvio al producto seleccionado
        public void gvOrderDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Si pulsa Volver al producto
            if (e.CommandName == "ReturnProduct")
            {
                // Obtengo el nombre del producto desde el CommandArgument
                string productName = e.CommandArgument.ToString();


                // Crea el contexto de datos
                var contextP = new ApplicationDbContext();

                // Localiza el producto en el listado de productos
                var product = contextP.Products.FirstOrDefault(p => p.Name == productName);

                // Si el producto se encuentra, redirige a la página de edición del producto
                if (product != null)
                {
                    int id = product.Id;
                    Response.Redirect("~/admin/ProductEdit.aspx?id=" + id);
                }
                else
                {
                    Response.Write("Producto no encontrado.");
                }

            }
        }

        //Metodo para mostra el email del usuario y no el Id
        public string GetUserEmail(object userId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.Find(userId);
            return user.Email;
        }
    }
}
