$(document).ready(function () {

    $(".btnEdit").click(function () {

        var id = $(this).data("value");

        $("#conteudoModal").load("/Imoveis/Edit/" + id,
            function () {
                $("#myModal").modal("show");
            }
        );
    })


    $(".btnDelete").click(function () {

        var id = $(this).data("value");

        $("#conteudoModal").load("/Imoveis/Delete/" + id,
            function () {
                $("#myModal").modal("show");
            }
        );
    });
});