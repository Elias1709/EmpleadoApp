﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Inicializador
{
    public class DbInicializador : IdbInicializador
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<UsuarioAplicacion> _userManager;
        private readonly RoleManager<RolAplicacion> _roleManager;

        public DbInicializador(ApplicationDbContext db, UserManager<UsuarioAplicacion> userManager, RoleManager<RolAplicacion> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Inicializar()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0) 
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw;
            }

            if (_db.Roles.Any(r => r.Name == "Admin")) return;

             _roleManager.CreateAsync(new RolAplicacion { Name = "Admin" }).GetAwaiter().GetResult();
             _roleManager.CreateAsync(new RolAplicacion { Name = "Empleado" }).GetAwaiter().GetResult();

            var usuario = new UsuarioAplicacion
            {
                UserName = "administrador",
                Email = "administrador@empleadoapp.com",
                Nombres = "Elias",
                Apellidos = "Cordoba"
            };
            _userManager.CreateAsync(usuario, "Admin123").GetAwaiter().GetResult();

            UsuarioAplicacion usuarioAdmin = _db.UsuarioAplicacion.Where(u => u.UserName == "administrador").FirstOrDefault();
            _userManager.AddToRoleAsync(usuarioAdmin, "Admin").GetAwaiter().GetResult();
        }
    }
}
