using FluentValidation;
using FluentValidation.AspNetCore;
using Hotels.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Hotel.Commands.CreateHotel
{
    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator(IHotelRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(64)
                .Custom((value, context) =>
                {
                    var exisitingHotel = repository.GetByName(value).Result;
                    if (exisitingHotel != null)
                    {
                        context.AddFailure($"{value} is not unique name for car workshop.");
                    }
                })
                .Custom((value, context) =>
                {
                    if (!char.IsUpper(value[0]))
                    {
                        context.AddFailure($"{value} does not start with uppercase letter.");
                    }
                });
            RuleFor(c => c.Description)
                .NotEmpty();
            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }

    }
}
