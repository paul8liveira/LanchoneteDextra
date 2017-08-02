//monitora click no item da lista de lanches
$(".list-group-item").click(function(){
	//obtem o span marcador de qntde
	var span = $(this).find("span");
	//muda valor do mesmo
	var spanVal = parseInt(span.text()) + 1;
	span.text(spanVal);	
	
	//exibe botão para confirmar pedido
	$("#btnConfirmar").show();
});

//evento do botão confirmar
$( "#btnConfirmar" ).click(function() {
	//percorre os itens da lista para verificar quais foram selecionados	
	var itens = [];
	$('.list-group-item').each(function(i, obj) {
		var span = $(obj).find("span");
		var spanVal = parseInt(span.text());
		if(spanVal > 0) {			
			itens.push({
                'IdLanche' : obj.id, 
                'Quantidade' : spanVal
            });			
		}					
	});	
	
	//envia lista de itens selecionados
	$.ajax({ 
		type: "post",
		datatype: "json",
        url: "/home/ConfirmarPedido/",
        data: { pedido: itens },          
        success: function (response) {
            $("#containerHome").html(response);
		}
	});
		
});