using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.DEL
{
    #region (CONTRA4)
    public class AuxiliarObra
    {
        //Declaramos los atributos de la clase
        private string numeroAux;
        private string anioCto;
        private string cedRuc; //Campo INCREMENTO de la tabla CONTRA4
        private string contratista;
        private string objetoCto;
        private string partida;
        private decimal montoCto;
        private string fechaCto;
        private string plazo;
        private string codigoCto; //Campo PRORROGA de la tabla CONTRA4
        //CAMPOS CALCULADOS TOMADOS DE LA TABLA CONTRA2
        private decimal sumvalEntregado; 
        private decimal sumvalDevengado; 
        private decimal sumvalMulta; 
        private decimal sumvalPlanillado;


        //Creamos un estado para controlar los errores
        private int estado_error;

        [Required]
        [Display(Name = "AuxId")]
        public string NumeroAux
        {
            get
            {
                return numeroAux;
            }

            set
            {
                numeroAux = value;
            }
        }

        public string AnioCto
        {
            get
            {
                return anioCto;
            }

            set
            {
                anioCto = value;
            }
        }
        public string CedRuc
        {
            get
            {
                return cedRuc;
            }

            set
            {
                cedRuc = value;
            }
        }

        public string Contratista
        {
            get
            {
                return contratista;
            }

            set
            {
                contratista = value;
            }
        }

        public string ObjetoCto
        {
            get
            {
                return objetoCto;
            }

            set
            {
                objetoCto = value;
            }
        }

        public string Partida
        {
            get
            {
                return partida;
            }

            set
            {
                partida = value;
            }
        }

        public decimal MontoCto
        {
            get
            {
                return montoCto;
            }

            set
            {
                montoCto = value;
            }
        }

        [Display(Name = "Fecha del Contrato")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string FechaCto
        {
            get
            {
                return fechaCto;
            }

            set
            {
                fechaCto = value;
            }
        }

        public string Plazo
        {
            get
            {
                return plazo;
            }

            set
            {
                plazo = value;
            }
        }

        public string CodigoCto
        {
            get
            {
                return codigoCto;
            }

            set
            {
                codigoCto = value;
            }
        }

        public int Estado_error
        {
            get
            {
                return estado_error;
            }

            set
            {
                estado_error = value;
            }
        }


        //CAMPOS CALCULADOS TOMADOS DE LA TABLA CONTRA4
        public decimal sumValEntregado
        {
            get
            {
                return sumvalEntregado;
            }

            set
            {
                sumvalEntregado = value;
            }
        }

        public decimal sumValDevengado
        {
            get
            {
                return sumvalDevengado;
            }

            set
            {
                sumvalDevengado = value;
            }
        }

        public decimal sumValMulta
        {
            get
            {
                return sumvalMulta;
            }

            set
            {
                sumvalMulta = value;
            }
        }

        public decimal sumValPlanillado
        {
            get
            {
                return sumvalPlanillado;
            }

            set
            {
                sumvalPlanillado = value;
            }
        }
        //FIN CAMPOS CALCULADOS


        //Contructores
        public AuxiliarObra()
        {

        }
  
        public AuxiliarObra(string numeroAux)
        {
            this.NumeroAux = numeroAux;
        }

        public AuxiliarObra(string numeroAux, string anioCto, string cedRuc, string contratista, string objetoCto, string partida, 
                            decimal montoCto, string fechaCto, string plazo, string codigoCto, int estado_error,
                            decimal sumvalEntregado, decimal sumvalDevengado, decimal sumvalMulta, decimal sumvalPlanillado)
        {
            this.NumeroAux = numeroAux;
            this.AnioCto = anioCto;
            this.CedRuc = cedRuc;
            this.Contratista = contratista;
            this.ObjetoCto = objetoCto;
            this.Partida = partida;
            this.MontoCto = montoCto;
            this.FechaCto = fechaCto;
            this.Plazo = plazo;
            this.CodigoCto = codigoCto;
            this.Estado_error = estado_error;
            this.sumValEntregado = sumvalEntregado;
            this.sumValDevengado = sumvalDevengado;
            this.sumValMulta = sumvalMulta;
            this.sumValPlanillado = sumvalPlanillado;
        }
    }
    #endregion

    #region (CONTRA2)
    public class AuxiliarObraDet
    {
        //Declaramos los atributos de la clase
        private string numeroAux;
        private string numeroPla; //pla: Planilla
        private string docControl;
        private string docReferencia; //Campo CHEQUE de la tabla CONTRA2
        private string concepto;
        private string fechaPago;
        private decimal valorMulta;
        private decimal retencionPla; //pla: Planilla
        private decimal valorEntregado; //Ent: Entregado
        private decimal valorPlanilla;
        private decimal valorReajuste;
        private decimal valorInec;
        private decimal valorFinanzas; ////Campo FINAN de la tabla CONTRA2

        //ENTIDAD CONTRA2
        public string NumeroAux
        {
            get
            {
                return numeroAux;
            }

            set
            {
                numeroAux = value;
            }
        }
       
        public string NumeroPla
        {
            get
            {
                return numeroPla;
            }

            set
            {
                numeroPla = value;
            }
        }

        public string DocControl
        {
            get
            {
                return docControl;
            }

            set
            {
                docControl = value;
            }
        }

        public string DocReferencia
        {
            get
            {
                return docReferencia;
            }

            set
            {
                docReferencia = value;
            }
        }

        public string Concepto
        {
            get
            {
                return concepto;
            }

            set
            {
                concepto = value;
            }
        }

        public string FechaPago
        {
            get
            {
                return fechaPago;
            }

            set
            {
                fechaPago = value;
            }
        }

        public decimal ValorMulta
        {
            get
            {
                return valorMulta;
            }

            set
            {
                valorMulta = value;
            }
        }

        public decimal RetencionPla
        {
            get
            {
                return retencionPla;
            }

            set
            {
                retencionPla = value;
            }
        }

        public decimal ValorEntregado
        {
            get
            {
                return valorEntregado;
            }

            set
            {
                valorEntregado = value;
            }
        }

        public decimal ValorPlanilla
        {
            get
            {
                return valorPlanilla;
            }

            set
            {
                valorPlanilla = value;
            }
        }

        public decimal ValorReajuste
        {
            get
            {
                return valorReajuste;
            }

            set
            {
                valorReajuste = value;
            }
        }

        public decimal ValorInec
        {
            get
            {
                return valorInec;
            }

            set
            {
                valorInec = value;
            }
        }

        public decimal ValorFinanzas
        {
            get
            {
                return valorFinanzas;
            }

            set
            {
                valorFinanzas = value;
            }
        }

        //Contructores
        public AuxiliarObraDet()
        {

        }

        public AuxiliarObraDet(string numeroAux)
        {
            this.NumeroAux = numeroAux;
        }

        public AuxiliarObraDet(string numeroAux, string numeroPla, string docControl, string docReferencia, string concepto, 
                                string fechaPago, decimal valorMulta, decimal retencionPla, decimal valorEntregado, 
                                decimal valorPlanilla, decimal valorReajuste, decimal valorInec, decimal valorFinanzas)
        {
            this.NumeroAux = numeroAux;
            this.NumeroPla = numeroPla;
            this.DocControl = docControl;
            this.DocReferencia = docReferencia;
            this.Concepto = concepto;
            this.FechaPago = fechaPago;
            this.ValorMulta = valorMulta;
            this.RetencionPla = retencionPla;
            this.ValorEntregado = valorEntregado;
            this.ValorPlanilla = valorPlanilla;
            this.ValorReajuste = valorReajuste;
            this.ValorInec = valorInec;
            this.ValorFinanzas = valorFinanzas;
        }
    }
    #endregion
}
