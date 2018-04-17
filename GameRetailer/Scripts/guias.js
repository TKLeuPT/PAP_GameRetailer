$(document).ready(function () {
    $(function () {
        var ddlGuias = $("#ddlGuias");
        ddlGuias.empty().append('<option selected="selected" value="0" disabled = "disabled">A carregar guias...</option>');
        $.ajax({
            type: "POST",
            url: "/GameRetailer/CabecalhoGuias/FetchGuias",
            data: '{}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                ddlGuias.empty().append('<option selected="selected" value="0">Escolha uma Guia</option>');
                var toAppend = '';
                $.each(response, function (i, o) {
                    toAppend += ('<option value="'
                        + o.ID + '">'
                        + o.ID + '</option>');
                });

                ddlGuias.append(toAppend);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });

        $(document).ready(function () {

        });

        $("#ddlGuias").change(function () {

            if ($("#ddlGuias").val() === "0") {
                $("#DatEntrada").val(" ");

                $("#remetente").text(" ");
                $("#moradaRe").text(" ");
                $("#localidadeRe").text(" ");
                $("#codpostalRe").text(" ");

                $("#destinatario").text(" ");
                $("#moradaDe").text(" ");
                $("#localidadeDe").text(" ");
                $("#codpostalDe").text(" ");

                $("#DatSaida").val(" ");
                $("#NumBungalow").val(" ");
                $("#NumBungalow").val(" ");
                //$("#datatable tr").remove();
            }

            $.ajax({
                type: 'POST',
                url: '/GameRetailer/CabecalhoGuias/FetchGuiasByID',
                dataType: 'json',
                data: { id: $("#ddlGuias").val() },
                success: function (a) {

                    $.each(a, function (i, a) {

                        //Convert Dates
                        var datEmissao = a.DataEmissao;
                        var cdatEmissao = new Date(parseInt(datEmissao.replace(/(^.*\()|([+-].*$)/g, '')));
                        var cdatEEmissao = cdatEmissao.toLocaleDateString();
                        var fdatEmiissao = cdatEEmissao.split("/").reverse().join("-");
                        //End of convert

                        $("#DatEntrada").val(fdatEmiissao);

                        $("#remetente").text(a.Armazem.Nome);
                        $("#moradaRe").text(a.Armazem.Morada);
                        $("#localidadeRe").text(a.Armazem.Localidade);
                        $("#codpostalRe").text(a.Armazem.CodPostal);

                        $("#destinatario").text(a.Cliente.Nome);
                        $("#moradaDe").text(a.Cliente.Morada);
                        $("#localidadeDe").text(a.Cliente.Localidade);
                        $("#codpostalDe").text(a.Cliente.CodPostal);

                        $("#distribuidor").text(a.Distribuidor.Nome);
                        $("#marca").text(a.Viatura.Marca);
                        $("#modelo").text(a.Viatura.Modelo);
                        $("#matricula").text(a.Viatura.Matricula);

                        $.ajax({
                            type: 'POST',
                            url: '/GameRetailer/CabecalhoGuias/FetchDetalhesByID',
                            dataType: 'json',
                            data: { id: $("#ddlGuias").val() },
                            success: function (json) {
                                $("#datatable tbody tr").remove();

                                var tr;
                                //Append each row to html table
                                for (var i = 0; i < json.length; i++) {
                                    tr = $('<tr/>');
                                    tr.append("<td class='numdguia hidden'>" + json[i].NumDGuia + "</td>");
                                    tr.append("<td>" + json[i].Quantidade + "</td>");
                                    tr.append("<td>" + json[i].Jogo.Nome + "</td>");
                                    tr.append("<td>" + json[i].Jogo.CodBarras + "</td>");
                                    tr.append("<td>" + json[i].Jogo.Preco + "€</td>");

                                    $('#datatable').append(tr);
                                }

                                $("#datatable tbody tr").mouseenter(function () {

                                    $(this).attr('id', 'ID');
                                    $(this).append("<button class='btn btn-default fa fa-edit' id='editar' type='button'></button >");
                                    $(this).addClass("not-clickable").append("<button class='btn btn-default fa fa-close ' id='apagar' type='button'></button >");
                                    $("#editar").on("click", function () {
                                        var id = $("#ID").children('td:first').text();
                                        console.log(id);
                                        var url = "../GameRetailer/DetalheGuias/Edit/" + id;
                                        window.location.href = url;
                                    });
                                    $("#apagar").on("click", function () {
                                        var id = $("#ID").children('td:first').text();
                                        console.log(id);
                                        var url = "../GameRetailer/DetalheGuias/Delete/" + id;
                                        window.location.href = url;
                                    });
                                });
                                $("#datatable tbody tr").mouseleave(function () {

                                    $(this).removeAttr('id', 'ID');
                                    $(this).find("button").remove();
                                });
                                //}, function () {

                                //    $(this).removeAttr('id', 'ID');
                                //    $(this).find("button").remove();


                                //});


                            },
                            error: function (ex) {
                                alert('Failed.' + ex);
                            }
                        });

                    });
                },
                error: function (ex) {
                    alert('Failed.' + ex);
                }
            });
            return false;
        });
    })
    function print() {
        window.print();
    }
});