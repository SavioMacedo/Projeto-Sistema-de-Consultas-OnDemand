using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Barbar.Models.ViewModel.Consultas
{
    public class Cadastro
    {
        [Display(Name = "Nome da Consulta")]
        [Required(ErrorMessage = "O campo Nome da Consulta é obrigatório.")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Descrição da Consulta")]
        [Required(ErrorMessage = "O campo Descrição da Consulta é obrigatório.")]
        [MaxLength(150)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Código SQL é obrigatório.")]
        [Display(Name = "Código SQL")]
        public string SQL { get; set; }

        [Required(ErrorMessage = "O campo Matrícula do Usuário Chave é obrigatório.")]
        [Display(Name = "Matricula do Usuario Chave")]
        public long Usua_Chave { get; set; }
        
        public DateTime DT_CRIACAO { get { return DateTime.Now; } }
        public string IC_ATIVO { get { return "Sim"; } }
        public string Versao_descricao { get { return "Versão Inicial"; } }
        public DateTime Versao_dt_criacao { get { return DateTime.Now; } }
        public DateTime Assoc_dt_criacao { get { return DateTime.Now; } }
        public long Assoc_tipo_criador { get { return 2; } }
        public long Assoc_tipo_usuachave { get { return 1; } }
        public long Usuario_Criador { get { return 1; } }
    }
}
