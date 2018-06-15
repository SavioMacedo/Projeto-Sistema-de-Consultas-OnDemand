//import { URL } from "url";

// Write your JavaScript code.
window.addEventListener("load", function () {

    document.getElementById("executar").addEventListener("click", function () { ExecutarConsulta(this); });
    
});

function ExecutarConsulta(element) 
{
    var Formulario = document.querySelectorAll("[data-type='parametro']");
    var Id = element.getAttribute("data-id");
    
    var params = [];

    var getUrl = window.location;
    var baseUrl = getUrl.protocol + "//" + getUrl.host;
    

    Formulario.forEach(function (elemento) {
        params.push(
            {
                NOME: elemento.name,
                DESCRICAO: elemento.value
            }
        );
    });
    var param = { Id: Id, Parametros: params };
    var url = new URL(baseUrl + "/Consultas/Executar");

    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(param),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (success) {
            var fileGuid = success.data.fileGuid;
            var fileName = success.data.fileName;

            window.open(baseUrl + "/Consultas/Download/?fileGuid=" + fileGuid + "&fileName=" + fileName, "_blank");
            location.reload();
        },
        error: function (error) {
            location.reload();
        }
    });


    //fetch(url, {
    //    body: JSON.stringify(param),
    //    credentials: 'same-origin', // include, same-origin, *omit
    //    headers: {
    //        'Content-Type': 'application/json;'
    //    },
    //    method: 'POST', // *GET, POST, PUT, DELETE, etc.
    //    mode: 'cors', // no-cors, cors, *same-origin
    //    redirect: 'follow', // manual, *follow, error
    //    referrer: 'no-referrer', // *client, no-referrer 
    //})
    //    .then(response => response.blob())
    //    .then(blob => URL.createObjectURL(blob))
    //    .then(url => {
    //        window.open(url, '_blank');
    //        URL.revokeObjectURL(url);
    //    });
}