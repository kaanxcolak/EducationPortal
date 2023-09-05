
using Microsoft.AspNetCore.Identity;
using EducationPortalEL.IdentityModels;
using EducationPortalBL.InterfacesOfManagers;
using EducationPortalEL.ViewModels;

namespace KargomentoUI.DefaultData
{
    public class DataDefault
    {
        public void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            try
            {
                //admin // student  // misafir vb...
                string[] roles = new string[] { "Admin", "Student", "Trainer" };

                // rolleri tek tek dönüp sisteme olup olmadığına bakacağız. Yoksa ekleyeceğiz.
                foreach (var item in roles)
                {
                    // ROLDEN YOK MU? 
                    if (!roleManager.RoleExistsAsync(item.ToLower()).Result)
                    {
                        //rolden yokmuş ekleyelim
                        AppRole role = new AppRole()
                        {
                            Name = item
                        };

                        var result = roleManager.CreateAsync(role).Result;
                    }
                }



            }
            catch (Exception ex)
            {
                // ex loglanabilşr
                // yazılımcıya acil başlıklı email gönderilebilir
            }
        }

      


        public void CreateAFewStudent(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IStudentManager studentManager)
        {
            try
            {
                List<AppUser> userList= new List<AppUser>();
                
                AppUser user = new AppUser
                {
                    Name="Betül",
                    Surname="Akşan",
                    TcNo="31471487892",
                    PhoneNumber="5396796650",
                    Email="betulaksan1992@gmail.com",
                    EmailConfirmed=false,
                    UserName= "31471487892"
                };
                
                userList.Add(user);
                

                foreach (var item in userList)
                {
                    if (userManager.FindByEmailAsync(item.Email).Result==null &&
                        userManager.FindByNameAsync(item.UserName).Result==null)
                        
                    {
                        var userResult = userManager.CreateAsync(item, "k1234").Result;

                        var roleResult =
                            userManager.AddToRoleAsync(item, "Employee").Result;
                        StudentVM b = new StudentVM
                        {
                            Id = item.Id,                            
                            CreatedDate = DateTime.Now,
                            IsRemoved = false,
                        };
                        studentManager.Add(b);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
