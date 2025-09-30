using BrokerDLL.Backend.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BrokerDLL.Backend.Controllers
{
    public class TagController: IController
    {
        ITag View;
        public TagController(ITag view)
        {
            View = view;
        }
        public void OnViewInitialize()
        {
            if (!Roles.IsUserInRole(Commons.UserName, "Admin"))
            {
                HttpContext.Current.Response.RedirectToRoute("Login");
                return;
            }
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.FillParentTagsList(Context.Tags.Where(K => K.ParentTagID == null).OrderBy(K => K.Name).ToList());
                View.BindList(Context.Tags.OrderBy(C => C.Name).ToList());
                View.Mode = PageMode.Add;
                View.Navigate();
            }
        }

        public void OnSave()
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    Tag tag;
                    if (View.Mode == PageMode.Add)
                    {
                        tag = View.FillObject(new Tag());
                        //tag.Code = "Gen-" + DateTime.Now.Ticks;
                        //SiteMapGenerator.AddGeneralNode(tag.URL, tag.Code, tag.Keywords);
                        Context.Tags.AddObject(tag);
                    }
                    else
                    {
                        tag = View.FillObject(Context.Tags.FirstOrDefault(C => C.ID == View.TagId));
                        if (tag.ChildremTags.Count > 0 && tag.ParentTagID != null)
                        {
                            View.NotifyUser(Message.KeywordHasChildren, MessageType.Error);
                            return;
                        }
                       // SiteMapGenerator.EditGeneralNode(tag.URL, tag.Code, tag.Keywords);
                    }
                    Context.SaveChanges();
                    View.BindList(Context.Tags.OrderBy(C => C.Name).ToList());
                    View.Mode = PageMode.Add;
                    View.Navigate();
                    View.NotifyUser(Message.Save, MessageType.Success);
                }

            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public void OnEdit(int ID)
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                View.TagId = ID;
                View.FillControls(Context.Tags.FirstOrDefault(C => C.ID == ID));
                View.Mode = PageMode.Edit;
                View.Navigate();
            }
        }
        public void OnDelete(int ID)
        {
            try
            {
                using (BrokerEntities Context = new BrokerEntities())
                {
                    Tag tag = Context.Tags.FirstOrDefault(C => C.ID == ID);
                    if (tag != null)
                    {
                       // SiteMapGenerator.DeleteGeneralNode(tag.Code);
                        Context.Tags.DeleteObject(tag);
                        Context.SaveChanges();
                        View.NotifyUser(Message.Delete, MessageType.Success);
                        View.BindList(Context.Tags.OrderBy(C => C.Name).ToList());

                    }
                }
            }
            catch (Exception ex)
            {
                View.NotifyUser(ex.Message, MessageType.Error);
            }
        }

        public Tag OnGet()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                return Context.Tags.FirstOrDefault(C => C.ID == View.TagId);
            }
        }

        public List<Tag> OnNeedDataSource()
        {
            using (BrokerEntities Context = new BrokerEntities())
            {
                return Context.Tags.OrderBy(C => C.Name).ToList();
            }
        }
    }
}
