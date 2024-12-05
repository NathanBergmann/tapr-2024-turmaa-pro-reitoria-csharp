namespace microservproreitoria.src.labsCreation.entities
{
    public class Materials
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Qtd { get; set; }
        public string UnitMeasure { get; set; } = string.Empty;
    }
}
