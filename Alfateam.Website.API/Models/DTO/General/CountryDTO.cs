﻿using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.DTO.General
{
    public class CountryDTO : DTOModel<Country>
    {
        public string Title { get; set; }
        public string Code { get; set; }


        public bool IsHidden { get; set; }

        public int OfficialMainLanguageId { get; set; }



        [DTOFieldBindWith(nameof(Languages), typeof(Language))]
        public List<int> LanguagesIds { get; set; } = new List<int>();

        [ForClientOnly]
        public List<LanguageDTO> Languages { get; set; } = new List<LanguageDTO>();



        public int MainLanguageId { get; set; }


        public int MainCurrencyId { get; set; }



        [DTOFieldBindWith(nameof(Currencies), typeof(Currency))]
        public List<int> CurrenciesIds { get; set; } = new List<int>();

        [ForClientOnly]
        public List<CurrencyDTO> Currencies { get; set; } = new List<CurrencyDTO>();


    }
}
