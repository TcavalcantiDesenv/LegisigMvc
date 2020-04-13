namespace Model.Entity
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public string DiaDaSemana { get; set; }
        public string HoraDeExecucao { get; set; }

        public Agendamento(int id)
        {
            this.AgendamentoId = id;
        }
        public Agendamento()
        {

        }
    }
}