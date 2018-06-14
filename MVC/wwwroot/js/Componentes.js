window.addEventListener('load', function () {

    var formAction = Array.from(document.querySelectorAll('[data-ajax="true"]'));
    for (var i = 0; i < formAction.length; i++) {
        formAction[i].addEventListener('click', function (element) {
            element.preventDefault();
            var param = {};

            var forms = this.form;

            for (var l = 0; l < forms.length; l++) {

                param[forms[l].id] = forms[l].value;

            }

            var listP = new Array();

            var table = document.querySelectorAll('[data-prop]');
            var tipos = document.querySelectorAll('[data-prop-tipo]');

            if (table !== undefined) {
                for (var z = 0; z < table.length; z++) {
                    var p = {};

                    p.NOME = table[z].getAttribute('data-prop');
                    p.DESCRICAO = table[z].value;
                    p.Tipo_ParametroID = tipos[z].value;
                    listP.push(p);
                }
            }

            param.Parametros = listP;

            var getUrl = window.location;
            var baseUrl = getUrl.protocol + "//" + getUrl.host;
            var url = new URL(baseUrl + "/Consultas/Cadastrar");

            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify(param),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function (success)
                {
                    alert('CadastrarAsync');
                    location.reload();
                },
                error: function (error) {
                    alert('Erro!');
                    //location.reload();
                }
            });

        });
    }

});