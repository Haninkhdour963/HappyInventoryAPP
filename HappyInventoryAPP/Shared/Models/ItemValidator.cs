

using FluentValidation;


namespace HappyInventoryAPP.Shared.Models
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            CascadeMode = CascadeMode.Stop;




            RuleFor(item => item.ItemName).NotEmpty().WithMessage("Item Name is a required field.")
                .Length(3, 50).WithMessage("Item Name must be between 3 and 50 characters.");

            RuleFor(item => item.SKUCode).NotEmpty().WithMessage("SKUCode is a required field.")
                .Length(3, 50).WithMessage("SKUCode must be between 3 and 50 characters.");

            RuleFor(item => item.Qty).NotEmpty().WithMessage("Qty is a required field.");

            RuleFor(item => item.CostPrice).NotEmpty().WithMessage("CostPrice is a required field.");

            RuleFor(item => item.MSRPPrice).NotEmpty().WithMessage("MSRPPrice is a required field.");

            RuleFor(item => item.Qty).GreaterThanOrEqualTo(1);
        }
    }
}