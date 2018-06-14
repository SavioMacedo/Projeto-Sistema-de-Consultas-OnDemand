﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CrossCutting.Models.ViewModels;

namespace CrossCutting.Models.ViewModels.Consultas
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
        public string Usua_Chave { get; set; }

        public string Usuario_Criador { get; set; }

        public List<Parametro> Parametros { get; set; }

        public DateTime DT_CRIACAO { get { return DateTime.Now; } }
        public string IC_ATIVO { get { return "Sim"; } }
        public string Versao_descricao { get { return "Versão Inicial"; } }
        public DateTime Versao_dt_criacao { get { return DateTime.Now; } }
        public DateTime Assoc_dt_criacao { get { return DateTime.Now; } }
        public long Assoc_tipo_criador { get { return 1; } }
        public long Assoc_tipo_usuachave { get { return 2; } }
        
    }
}