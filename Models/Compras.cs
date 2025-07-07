namespace ListaDeCompras.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; } = 0;
        public bool Comprado { get; set; } = false;
        public DateTime CriadoEm {  get; set; } = DateTime.Now;
    }
}