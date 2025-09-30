using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace BrokerWeb.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProjectService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProjectService : IProjectService
    {
        public void DoWork()
        {
        }


        public List<BrokerDLL.Serializable.Project> GetProjects(string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                List<BrokerDLL.Serializable.Project> Projects = new List<BrokerDLL.Serializable.Project>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstateProjects.Where(RS => RS.ActiveStatusID == (int)BrokerDLL.Activestatus.Active)
                    .OrderByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => Projects.Add(new BrokerDLL.Serializable.Project(RS)));
                return Projects;
            }
        }


        public List<BrokerDLL.Serializable.Project> GetBannerProject()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                // Random r = new Random();

                List<BrokerDLL.Serializable.Project> Projects = new List<BrokerDLL.Serializable.Project>();
                Context.RealEstateProjects.Where(RS => RS.ActiveStatusID == (int)BrokerDLL.Activestatus.Active && RS.AdPackageID == (int)BrokerDLL.AdvPackage.Banner).ToList()
                    .ForEach(RS => Projects.Add(new BrokerDLL.Serializable.Project(RS)));
                return Projects;
                //return Projects;
            }
        }


        public List<int> GetProjectsCount(string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                //  int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                List<int> Pages = new List<int>();
                int Count = Context.RealEstateProjects.Where(RS => RS.ActiveStatusID == (int)BrokerDLL.Activestatus.Active).Count();

                double counter = Convert.ToDouble(Count) / Size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
                //return Companies;
            }
        }

        public List<BrokerDLL.Serializable.Project> GetProjectsByCompany(string CompanyID, string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int ID = Convert.ToInt32(CompanyID);
                List<BrokerDLL.Serializable.Project> Projects = new List<BrokerDLL.Serializable.Project>();
                //BrokerDLL.BrokerEntities Context=new BrokerDLL.BrokerEntities();
                Context.RealEstateProjects.Where(RS => RS.CompanyID == ID && RS.ActiveStatusID == (int)BrokerDLL.Activestatus.Active)
                    .OrderByDescending(B => B.CreatedDate).Skip((Index - 1) * Size).Take(Size).ToList()
                    .ForEach(RS => Projects.Add(new BrokerDLL.Serializable.Project(RS)));
                return Projects;
            }
        }

        public List<int> GetCompanyProjectsCount(string CompanyID, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                //  int Index = Convert.ToInt32(PageIndex);
                int Size = Convert.ToInt32(PageSize);
                int ID = Convert.ToInt32(CompanyID);
                List<int> Pages = new List<int>();
                int Count = Context.RealEstateProjects.Where(RS => RS.CompanyID == ID && RS.ActiveStatusID == (int)BrokerDLL.Activestatus.Active).Count();

                double counter = Convert.ToDouble(Count) / Size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
                //return Companies;
            }
        }


        public BrokerDLL.Serializable.Project GetProject(string ID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                BrokerDLL.RealEstateProject project = Context.RealEstateProjects.FirstOrDefault(R => R.ID == id && R.ActiveStatusID == (int)BrokerDLL.Activestatus.Active);
                return new BrokerDLL.Serializable.Project(project);
            }
        }


        public List<BrokerDLL.Serializable.ProjectPhotos> GetProjectPhotoAlbum(string ID, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                int size = Convert.ToInt32(PageSize);
                List<BrokerDLL.Serializable.ProjectPhotos> Photos = new List<BrokerDLL.Serializable.ProjectPhotos>();
                Context.RealEstateProjectPhotos.Where(P => P.ProjectID == id).ToList().ForEach(P => Photos.Add(new BrokerDLL.Serializable.ProjectPhotos(P)));
                if (size == 0)
                {
                    size = Photos.Count();
                }
                return Photos.OrderByDescending(P => P.Date).GroupBy(P => P.Date).Select(P => P.FirstOrDefault()).Take(size).ToList();
                // Context.RealEstateProjectPhotos.Where(P=>P.ProjectID==id).Distinct(new 
                //  return new BrokerDLL.Serializable.Project(project);
            }
        }

        public List<BrokerDLL.Serializable.ProjectPhotos> GetProjectPhotos(string ID, string Date)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                // DateTime date = Convert.ToDateTime(Date);
                List<BrokerDLL.Serializable.ProjectPhotos> Photos = new List<BrokerDLL.Serializable.ProjectPhotos>();
                Context.RealEstateProjectPhotos.Where(P => P.ProjectID == id).ToList().ForEach(P => Photos.Add(new BrokerDLL.Serializable.ProjectPhotos(P)));
                return Photos.Where(P => P.Date == Date).ToList();
                // Context.RealEstateProjectPhotos.Where(P=>P.ProjectID==id).Distinct(new 
                //  return new BrokerDLL.Serializable.Project(project);
            }
        }


        public List<BrokerDLL.Serializable.ProjectVedio> GetProjectVedios(string ID, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                int size = Convert.ToInt32(PageSize);
                List<BrokerDLL.Serializable.ProjectVedio> Vedios = new List<BrokerDLL.Serializable.ProjectVedio>();
                if (size == 0)
                {
                    Context.RealEstateProjectVideos.Where(P => P.ProjectID == id).ToList().ForEach(P => Vedios.Add(new BrokerDLL.Serializable.ProjectVedio(P)));
                }
                else
                {
                    Context.RealEstateProjectVideos.Where(P => P.ProjectID == id).Take(size).ToList().ForEach(P => Vedios.Add(new BrokerDLL.Serializable.ProjectVedio(P)));
                }
                return Vedios;
                // Context.RealEstateProjectPhotos.Where(P=>P.ProjectID==id).Distinct(new 
                //  return new BrokerDLL.Serializable.Project(project);
            }
        }


        public List<BrokerDLL.Serializable.ProjectModel> GetProjectModels(string ID, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                int size = Convert.ToInt32(PageSize);
                List<BrokerDLL.Serializable.ProjectModel> Models = new List<BrokerDLL.Serializable.ProjectModel>();
                if (size == 0)
                {
                    Context.RealEstateProjectModels.Where(P => P.ProjectID == id).ToList().ForEach(P => Models.Add(new BrokerDLL.Serializable.ProjectModel(P)));
                }
                else
                {
                    Context.RealEstateProjectModels.Where(P => P.ProjectID == id).Take(size).ToList().ForEach(P => Models.Add(new BrokerDLL.Serializable.ProjectModel(P)));
                }
                return Models;
                // Context.RealEstateProjectPhotos.Where(P=>P.ProjectID==id).Distinct(new 
                //  return new BrokerDLL.Serializable.Project(project);
            }
        }

        public BrokerDLL.Serializable.ProjectModel GetProjectModel(string ID)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                BrokerDLL.RealEstateProjectModel model = Context.RealEstateProjectModels.FirstOrDefault(R => R.ID == id);
                return new BrokerDLL.Serializable.ProjectModel(model);
            }
        }


        public List<BrokerDLL.Serializable.Project> GetHomePageProject()
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                Random r = new Random();

                List<BrokerDLL.Serializable.Project> Projects = new List<BrokerDLL.Serializable.Project>();
                Context.RealEstateProjects.Where(RS => RS.ActiveStatusID == (int)BrokerDLL.Activestatus.Active && RS.AdPackageID == (int)BrokerDLL.AdvPackage.HomePage).ToList()
                    .ForEach(RS => Projects.Add(new BrokerDLL.Serializable.Project(RS)));
                //return Projects[r.Next(Projects.Count)];
                return Projects.Skip(r.Next(1, Projects.Count - 1) - 1).Take(2).ToList();

            }
        }

        public List<BrokerDLL.Serializable.RealEstate> GetProjectProperties(string ID, string PageIndex, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                int size = Convert.ToInt32(PageSize);
                int Index = Convert.ToInt32(PageIndex);
                List<BrokerDLL.Serializable.RealEstate> realestate = new List<BrokerDLL.Serializable.RealEstate>();

                Context.RealEstates.Where(P => P.ProjectID == id && P.IsSold == false && P.ActiveStatusId == (int)BrokerDLL.Activestatus.Active)
                    .OrderByDescending(P => P.CreatedDate).Skip((Index - 1) * size).Take(size).ToList().ForEach(P => realestate.Add(new BrokerDLL.Serializable.RealEstate(P)));

                return realestate;
                // Context.RealEstateProjectPhotos.Where(P=>P.ProjectID==id).Distinct(new 
                //  return new BrokerDLL.Serializable.Project(project);
            }
        }



        public List<int> CountProjectProperties(string ID, string PageSize)
        {
            using (BrokerDLL.BrokerEntities Context = new BrokerDLL.BrokerEntities())
            {
                int id = Convert.ToInt32(ID);
                int size = Convert.ToInt32(PageSize);
                int Count = Context.RealEstates.Where(P => P.ProjectID == id && P.IsSold == false && P.ActiveStatusId == (int)BrokerDLL.Activestatus.Active).Count();
                List<int> Pages = new List<int>();
                double counter = Convert.ToDouble(Count) / size;
                if (counter <= 0)
                {
                    return null;
                }
                double pagecount = Math.Ceiling(counter);
                for (int i = 1; i <= pagecount; i++)
                {
                    Pages.Add(i);
                }
                return Pages;
            }
        }
    }
}
