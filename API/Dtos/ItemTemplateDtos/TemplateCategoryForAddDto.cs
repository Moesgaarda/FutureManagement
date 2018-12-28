namespace API.Dtos.ItemTemplateDtos
{
    public class TemplateCategoryForAddDto
    {
        public string Name {get; set;}
        public ICollection <ItemTemplate> ItemTemplates {get; set;}
    }
}