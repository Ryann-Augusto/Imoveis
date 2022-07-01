function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

$(document).ready(function () {
    var qs = getUrlVars();
    if (qs["o"] != null) {
        $(".selectOrdem").val(qs["o"]);
        $("#o").val(qs["o"]);
    }

    if (qs["b"] != null) {
        $("#b").val(qs["b"])
    }

    if (qs["t"] != null) {
        $(".tamanhoPage").val(qs["t"]);
        $("#t").val(qs["t"]);
    }

});

$(".selectOrdem").change(function () {
    $("#o").val($(".selectOrdem").val());
    $("#formBusca").submit();
});

$(".page-link").click(function () {
    $("#p").val($(this).val());
    $("#formBusca").submit();
});

$(".tamanhoPage").change(function () {
    $("#t").val($(".tamanhoPage").val());
    $("#formBusca").submit();
});


$(document).ready(function () {

    $(".btnDeleteImovel").click(function () {

        var id = $(this).data("value");

        $("#conteudoModal").load("/Imoveis/Delete/" + id,
            function () {
                $("#myModal").modal("show");
            }
        );
    });

    $(".btnDeleteImage").click(function () {

        var id = $(this).data("value");

        $("#conteudoModal").load("/Imoveis/DeleteImage/" + id,
            function () {
                $("#myModal").modal("show");
            }
        );
    });

    $(".btnDeleteUsuario").click(function () {

        var id = $(this).data("value");

        $("#conteudoModal").load("/Usuarios/Delete/" + id,
            function () {
                $("#myModal").modal("show");
            }
        );
    });

    $(".btnImage").click(function () {

        var id = $(this).data("value");

        $("#conteudoModal").load("/Home/RecuperarImagem/" + id,
            function () {
                $("#myModal").modal("show");
            }
        );
    });

    $(".compWhats").click(function () {

        var id = $(this).data("id");
        var telefone = $(this).data("telefone");
        var descricao = $(this).data("descricao");
        var url_atual = window.location.href.replace("#","");

        //alert("Número de telefone: " + telefone + "\nDescrição: " + descricao);

        var texto = window.encodeURIComponent(descricao);
        var links = window.encodeURIComponent(url_atual);

        window.open("https://wa.me/55" + telefone + "?text=Eu%20tenho%20interesse%20no%20" + texto + "%20\n%20" + links + "Home/Visualizar/" + id);
    });
});


