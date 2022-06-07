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
        $("#selectOrdem").val(qs["o"]);
        $("#o").val(qs["o"]);
    }
    if (qs["b"] != null) {
        $("#b").val(qs["b"])
    }
});

$("#selectOrdem").change(function () {
    $("#o").val($("#selectOrdem").val());
    $("#formBusca").submit();
});


$(document).ready(function () {

    $(".btnDelete").click(function () {

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
});


