using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RegistroHora.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Roles.Any())
            {
                context.Roles.Add(
                    new IdentityRole { Name = "Administrator" }
                    );
            }

            if (!context.Users.Any()) {
                //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                //var user = new ApplicationUser()
                //{
                //    Email = "admin@mail.com",
                //    UserName = "admin@mail.com"
                //};

                //var res = manager.CreateAsync(user, $"*123456*");
                //if (res.IsCompleted)
                //{
                //    //Add To Admin Role Here
                //    manager.AddToRole(User.Id, "Admin");
                //}

                //var userStore = new UserStore<ApplicationUser>(context);
                //var userManager = new UserManager<ApplicationUser>(userStore);

                //var user = new ApplicationUser { UserName = "admin@creasys.cl" };
                //var result = userManager.CreateAsync(user, "1234");

                //var userStore = new UserStore<ApplicationUser>(context);
                //var userManager = new UserManager<ApplicationUser>(userStore);
                //var userToInsert = new ApplicationUser { UserName = "dj@dj.com", PhoneNumber = "0797697898" };
                //userManager.CreateAsync(userToInsert, "Password@123");
            }

            //if (!context.Proyecto.Any())
            //{
            //    var security = context.Proyecto.Add(
            //        new Proyecto { Nombre = "Security", NumHoras = 80, TipoHoras = "Semanales" }).Entity;
            //    var corpbanca = context.Proyecto.Add(
            //        new Proyecto { Nombre = "CorpBanca", NumHoras = 50, TipoHoras = "Semanales" }).Entity;
            //    var bci = context.Proyecto.Add(
            //        new Proyecto { Nombre = "BCI", NumHoras = 10, TipoHoras = "Semanales" }).Entity;

            //    var passwordHash = new PasswordHasher<ApplicationUser>();
            //    var usuario1 = context.Usuario.Add(new ApplicationUser { UserName = "Usuario1" }).Entity;
            //    string password = passwordHash.HashPassword(usuario1,"1234");
            //    usuario1.PasswordHash = password;

            //    var usuario2 = context.Usuario.Add(new ApplicationUser { UserName = "Usuario2", PasswordHash = password }).Entity;
            //    string password2 = passwordHash.HashPassword(usuario2,"1234");
            //    usuario2.PasswordHash = password2;

            //    context.Registro.AddRange(
            //        new Registro()
            //        {
            //            Horas = 5,
            //            Fecha = DateTime.Now,
            //            Proyecto = security,
            //            Usuario = usuario1
            //        },
            //        new Registro()
            //        {
            //            Horas = 2,
            //            Fecha = DateTime.Now,
            //            Proyecto = corpbanca,
            //            Usuario = usuario2
            //        },
            //        new Registro()
            //        {
            //            Horas = 1,
            //            Fecha = DateTime.Now,
            //            Proyecto = bci,
            //            Usuario = usuario1
            //        },
            //        new Registro()
            //        {
            //            Horas = 4,
            //            Fecha = DateTime.Now,
            //            Proyecto = security,
            //            Usuario = usuario2
            //        });
            //    context.SaveChanges();
            //}
        }
    }
}
