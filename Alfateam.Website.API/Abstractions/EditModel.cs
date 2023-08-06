﻿using Alfateam2._0.Models.Abstractions.Interfaces;

namespace Alfateam.Website.API.Abstractions
{
    public abstract class EditModel : IValidatableModel
    {
        public int Id { get; set; }
        public abstract bool IsValid();
    }


}
