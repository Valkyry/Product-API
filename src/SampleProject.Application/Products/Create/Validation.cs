﻿using FluentValidation;

namespace SampleProject.Application.Products
{
    public partial class Create
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Type).IsInEnum();
                RuleFor(x => x.Color).IsInEnum();
            }
        }
    }
}
