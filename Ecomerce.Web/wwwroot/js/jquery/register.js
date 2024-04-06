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


//Função CPF 

$(document).ready(function () {

    function limpa_formulário_cpf() {
        $("#FullName").val("");
        $("#DateOfBirth").val("");
    }

    $("#RegistrationOfIndividuals").blur(function () {

        var cpf = $(this).val().replace(/\D/g, '');

        if (cpf != "") {

            var validacpf = /^[0-9]{11}$/;

            if (validacpf.test(cpf)) {

                $("#FullName").val("");
                $("#DateOfBirth").val("");

                $.getJSON("http://ws.hubdodesenvolvedor.com.br/v2/cpf/?cpf=" + cpf + "&data=&token=144757125lRJQNMXWUP261354600", function (dados) {

                    if (!("erro" in dados)) {
                        console.log(dados);
                        $("#FullName").val(dados.result.nome_da_pf);
                        $("#DateOfBirth").val(dados.result.data_nascimento);
                    }
                    else {

                        limpa_formulário_cpf();
                        alert("Cpf não encontrado.");
                    }
                });
            } //end if.
            else {

                limpa_formulário_cpf();
                alert("Formato de Cpf inválido.");
            }
        } //end if.
        else {

            limpa_formulário_cpf();
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
        $("#AddressCnpj").val("");
        $("#NumberCnpj").val("");
        $("#NeighborhoodCnpj").val("");
        $("#ZipCodeCnpj").val("");
        $("#CityCnpj").val("");
        $("#StateCnpj").val("");
        $("#Members").val("");
    }

    $("#NationalRegisterOfLegalEntities").blur(function () {

        var cnpj = $(this).val().replace(/\D/g, '');

        if (cnpj != "") {

            var validacnpj = /^[0-9]{14}$/;

            if (validacnpj.test(cnpj)) {

                $("#CorporateReason").val("");
                $("#FantasyName").val("");
                $("#OpeningDate").val("");
                $("#Situation").val("");
                $("#AddressCnpj").val("");
                $("#NumberCnpj").val("");
                $("#NeighborhoodCnpj").val("");
                $("#ZipCodeCnpj").val("");
                $("#CityCnpj").val("");
                $("#StateCnpj").val("");
                $("#Members").val("");

                $.getJSON("http://ws.hubdodesenvolvedor.com.br/v2/cnpj/?cnpj=" + cnpj + "&token=144757125lRJQNMXWUP261354600", function (dados) {

                    if (!("erro" in dados)) {
                        $("#CorporateReason").val(dados.result.nome);
                        $("#FantasyName").val(dados.result.fantasia);
                        $("#OpeningDate").val(dados.result.abertura);
                        $("#Situation").val(dados.result.situacao);
                        $("#AddressCnpj").val(dados.result.logradouro);
                        $("#NumberCnpj").val(dados.result.numero);
                        $("#NeighborhoodCnpj").val(dados.result.bairro);
                        $("#ZipCodeCnpj").val(dados.result.cep);
                        $("#CityCnpj").val(dados.result.municipio);
                        $("#StateCnpj").val(dados.result.uf);
                        $("#Members").val(dados.result.quadro_socios);
                    }
                    else {

                        limpa_formulário_cnpj();
                        alert("Cpf não encontrado.");
                    }
                });
            } 
            else {

                limpa_formulário_cnpj();
                alert("Formato de Cpf inválido.");
            }
        } 
        else {

            limpa_formulário_cnpj();
        }
    });
});