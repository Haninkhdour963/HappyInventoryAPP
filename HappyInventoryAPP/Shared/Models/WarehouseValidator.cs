

using FluentValidation;


namespace HappyInventoryAPP.Shared.Models
{
    public class WarehouseValidator : AbstractValidator<Warehouse>
    {
        public WarehouseValidator()
        {

            CascadeMode = CascadeMode.Stop;




            RuleFor(warehouse => warehouse.WarehouseName).NotEmpty().WithMessage("Warehouse Name is a required field.")
                .Length(3, 50).WithMessage("Warehouse Name must be between 3 and 50 characters.");

            RuleFor(warehouse => warehouse.Country).NotEmpty().WithMessage("Country is a required field.")
                .Length(3, 50).WithMessage("Country must be between 3 and 50 characters.");

            RuleFor(warehouse => warehouse.Address).NotEmpty().WithMessage("Address is a required field.")
                .Length(3, 100).WithMessage("Address must be between 3 and 50 characters.");

            RuleFor(warehouse => warehouse.City).NotEmpty().WithMessage("City is a required field.")
                .Length(3, 50).WithMessage("City must be between 3 and 50 characters.");



        }
    }
}