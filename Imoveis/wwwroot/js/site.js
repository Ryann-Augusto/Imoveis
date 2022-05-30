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