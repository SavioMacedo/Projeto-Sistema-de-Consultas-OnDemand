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


    //Tela de Busca
    var time = new Date();
    var busca = document.getElementById('inputBusca');

    busca.addEventListener('keyup', function () {

        var timeNow = new Date();
        
        if (((time - timeNow) / (1000 * 3600 * 24 * 60 * 60)) < 5)
            return;

        time = new Date();

        $.ajax({
            type: 'POST',
            url: '/Consultas/Editar',
            data: JSON.stringify(busca.value),
            success: 
        });
    });


    $("html").on("click", ".ac_results ul li", function (e) {
        var li = $(this);
        var filtro = $("#pesquisa-central");
        filtro.val(li.data("text"));
        buscaSistemas(li.data("text"));
        showAutoCompleteResults(false);
    });
    $("html").on("blur", ".ac_results ul", function (e) {
        $(".ac_results ul li.active").removeClass("active");
    });
    $("html").on("hover", ".ac_results li", function (e) {
        $("#pesquisa-central").focus();
        var $this = $(this);
        if (e.type == "mouseleave") {
            $(e.currentTarget).removeClass("active");
        } else {
            $(e.currentTarget).addClass("active");
        }
    });
    $("html").on("keydown", ".ac_results li", function (e) {
        var $this = $(this);
        var other = null;
        if (e.keyCode == 38) { other = $this.prev(); }
        if (e.keyCode == 40) { other = $this.next(); }
        if (other != null) {
            $this.removeClass("active");
            if (other.html() == undefined) {
                $("#pesquisa-central").focus();
            } else {
                $(other).focus();
                $(other).addClass("active");

            }

        }
        if (e.keyCode == 13) {
            return $this.click();
        }
        if (e.keyCode == 38 || e.keyCode == 40) return false;

    });

});


function showAutoCompleteResults(show) {
    if (show) {
        $("div.ac_results").show();
        resizeAutoComplete();
    } else {
        $("div.ac_results").hide();
    }

}