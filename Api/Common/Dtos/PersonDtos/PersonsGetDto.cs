﻿namespace CVGeneratorApp.Api.Common.Dtos.PersonDtos
{
    public class PersonsGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MobilePhone { get; set; }=null!;
        public string SectorName { get; set; } = null!;
        public string CVFilePath { get; set; } = null!;
    }
}
