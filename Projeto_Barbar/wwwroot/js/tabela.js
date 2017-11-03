var parametros = [];
//var quantidadeLinhas = $("#tab_logic tr").length;

//parametrosRAM.push(bancoDeDados.Parametros);

function AtualizarQuadro() {
    var regex = /@(\w+)/g;
    var palavras = $("#SQL").val();
    var array;
    var j;
    var i = 0;
    var k = 0;
    for (j = 0; j < parametros.length; j++) {
        if (document.getElementById("idApelido-" + j)) {
            parametros[j].Apelido = document.getElementById("idApelido-" + j).value;
        }
    }
    if (parametros.length == 0) {
        while ((array = regex.exec(palavras)) != null) {
            parametros[i] = { Nome: array[1], Apelido: "" };
            i++;
            k++;
        }
    }
    else {
        while ((array = regex.exec(palavras)) != null) {
            for (j = 0; j < parametros.length; j++) {
                if (parametros[j].Nome == array[1]) {
                    parametros[i] = { Nome: parametros[j].Nome, Apelido: parametros[j].Apelido };
                    i++;
                    break;
                }
                if (j == parametros.length - 1) {
                    parametros[i] = { Nome: array[1], Apelido: "" };
                    i++;
                    break;
                }
            }
            k++;
        }
    }
    if (k < parametros.length) {
        parametros.splice(k, parametros.length - 1);
    }
    refazerTudo();
}
function refazerTudo() {
    deletarTudo();
    var tab = document.createElement("tbody");
    tab.id = "tab";
    var i;
    for (i = 0; i < parametros.length; i++) {
        if (parametros[i]) {
            var tabela = document.getElementById("tab_logic");
            var tr = document.createElement("tr");
            var tdPos = document.createElement("td");
            var tdNome = document.createElement("td");
            var tdApelido = document.createElement("td");
            var tdTipo = document.createElement("td");
            var buttonDelete = document.createElement("button");

            var inputApelido = document.createElement("input");
            var selectTipo = document.createElement("select");
            var optionSelect = document.createElement("option");

            optionSelect.appendChild(document.createTextNode("Selecione..."));

            buttonDelete.className = "btn btn-sm btn-danger";
            buttonDelete.setAttribute("onclick", "Deletar(" + i + ")");
            buttonDelete.innerHTML = "Deletar";

            selectTipo.id = "TipoSeletor"+i;
            selectTipo.className = "form-control";

            inputApelido.id = "idApelido-" + i;
            inputApelido.value = parametros[i].Apelido;
            inputApelido.type = "text";
            inputApelido.placeholder = "Apelido";
            inputApelido.className = "form-control input-md";

            tdPos.appendChild(buttonDelete);
            tdPos.align = "center";
            tdNome.innerHTML = parametros[i].Nome;
            tr.id = "addr-" + i;

            selectTipo.appendChild(optionSelect);
            tdTipo.appendChild(selectTipo);
            tdApelido.appendChild(inputApelido);
            tr.appendChild(tdPos);
            tr.appendChild(tdNome);
            tr.appendChild(tdApelido);
            tr.appendChild(tdTipo);
            tab.appendChild(tr);
            tabela.appendChild(tab);

        }
    }
}
function deletarTudo() {
    var tab = document.getElementById("tab");
    if (tab) {
        tab.remove();
    }
    total = 0;
}
function Deletar(id) {
    parametros.splice(id, 1);
    document.getElementById("addr-" + id).remove();
    refazerTudo();
}
    /*function validaParametro(param) {
        var i;
        for (i = 0; i < parametros.length; i++){
            if (parametros[i]) {
                if (parametros[i].Nome == param.Nome) {
                    return false;
                }
            }
        }
        return true;
    }*/
