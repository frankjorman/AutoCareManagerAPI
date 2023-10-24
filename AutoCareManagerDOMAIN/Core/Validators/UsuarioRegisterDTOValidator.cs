using AutoCareManagerDOMAIN.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCareManagerDOMAIN.Core.Validators
{
    public class UsuarioRegisterDTOValidator:AbstractValidator<UsuarioRegisterDTO>
    {
        public UsuarioRegisterDTOValidator() {
            RuleFor(x => x.Username).NotEmpty().WithMessage("El nombre de usuario es requerido");
            RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña es requerida");
            RuleFor(x => x.Rol).NotEmpty().WithMessage("El rol es requerido");
            RuleFor(x => x.IdEmpleado).NotEmpty().WithMessage("El id del empleado es requerido");
        }
        
    }
}
