using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectFile
{
    class MovimentoFileExecel
    {
        public string Sinistro { get; set; }
        public string Data      { get; set; }
        public string Placa     { get; set; }
        public string Diversos  { get; set; }
        public string Local     { get; set; }
        public string Estado    { get; set; }
        public string Total     { get; set; }

        public MovimentoFileExecel(string sinistro, string data, string placa, string diversos, string local, string estado, string total)
        {
            Sinistro = sinistro;
            Data = data;
            Placa = placa;
            Diversos = diversos;
            Local = local;
            Estado = estado;
            Total = total;
        }

        public override string ToString()
        {
            return  Sinistro    + " - "
                    +Data       + " - "
                    +Placa      + " - "
                    +Diversos   + " - "
                    +Local      + " - "
                    +Estado     + " - "
                    +Total;
        }



    }
}
