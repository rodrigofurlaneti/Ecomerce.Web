//Função CEP 
    $(document).ready(function () {

        function limpa_formulário_cep() {
            $("#Address").val("");
            $("#Neighborhood").val("");
            $("#City").val("");
            $("#State").val("");
            $("#ibge").val("");
        }
            
            $("#ZipCode").blur(function() {

                var cep = $(this).val().replace(/\D/g, '');

            if (cep != "") {

                            var validacep = /^[0-9]{8}$/;

            if(validacep.test(cep)) {

                $("#Address").val("");
                $("#Neighborhood").val("");
                $("#City").val("");
                $("#State").val("");
                $("#ibge").val("");

    $.getJSON("https://viacep.com.br/ws/"+ cep +"/json/?callback=?", function(dados) {

        if (!("erro" in dados))
        {
            console.log(dados);
            $("#Address").val(dados.logradouro);
            $("#Neighborhood").val(dados.bairro);
            $("#City").val(dados.localidade);
            $("#State").val(dados.uf);
            $("#ibge").val(dados.ibge);
        } 
            else {

                limpa_formulário_cep();
            alert("CEP não encontrado.");
                                    }
                                });
                            } //end if.
            else {

                limpa_formulário_cep();
            alert("Formato de CEP inválido.");
                            }
                        } //end if.
            else {

                limpa_formulário_cep();
                        }
                    });
    });


//Função CNPJ

$(document).ready(function () {

    function limpa_formulário_cnpj() {
        $("#CorporateReason").val("");
        $("#FantasyName").val("");
        $("#OpeningDate").val("");
        $("#Situation").val("");
        $("#Address").val("");
        $("#Number").val("");
        $("#Neighborhood").val("");
        $("#ZipCode").val("");
        $("#City").val("");
        $("#State").val("");
        $("#Members").val("");
    }

    $("#NationalRegisterOfLegal").blur(function () {

        var cnpj = $(this).val().replace(/\D/g, '');

        if (cnpj != "") {

            var validacnpj = /^[0-9]{14}$/;

            if (validacnpj.test(cnpj)) {

                $("#CorporateReason").val("");
                $("#FantasyName").val("");
                $("#OpeningDate").val("");
                $("#Situation").val("");
                $("#Address").val("");
                $("#Number").val("");
                $("#Neighborhood").val("");
                $("#ZipCode").val("");
                $("#City").val("");
                $("#State").val("");
                $("#Members").val("");

                $.getJSON("http://ws.hubdodesenvolvedor.com.br/v2/cnpj/?cnpj=" + cnpj + "&token=144757125lRJQNMXWUP261354600", function (dados) {

                    if (!("erro" in dados)) {
                        $("#CorporateReason").val(dados.result.nome);
                        $("#FantasyName").val(dados.result.fantasia);
                        $("#OpeningDate").val(dados.result.abertura);
                        $("#Situation").val(dados.result.situacao);
                        $("#Address").val(dados.result.logradouro);
                        $("#Number").val(dados.result.numero);
                        $("#Neighborhood").val(dados.result.bairro);
                        $("#ZipCode").val(dados.result.cep);
                        $("#City").val(dados.result.municipio);
                        $("#State").val(dados.result.uf);
                        $("#Members").val(dados.result.quadro_socios);
                    }
                    else {

                        limpa_formulário_cnpj();
                        alert("Cnpj não encontrado.");
                    }
                });
            } 
            else {

                limpa_formulário_cnpj();
                alert("Formato de Cnpj inválido.");
            }
        } 
        else {

            limpa_formulário_cnpj();
        }
    });
});