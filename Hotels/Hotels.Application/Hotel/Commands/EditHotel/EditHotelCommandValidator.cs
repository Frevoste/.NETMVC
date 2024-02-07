using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Commands.EditHotel
{
    public class EditHotelCommandValidator : AbstractValidator<EditHotelCommand>
    {
        public EditHotelCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty();
            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
