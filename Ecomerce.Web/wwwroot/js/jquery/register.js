    $(document).ready(function() {

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