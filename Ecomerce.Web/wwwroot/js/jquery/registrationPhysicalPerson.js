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