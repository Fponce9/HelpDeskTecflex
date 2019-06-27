$(function(){
	//GET/READ
        var labels = ["RUC","Razon Socila","Direccion","Telefono","Correo"," "];
        var $dato_c = $('#datos');
        var aux = 0
		$.ajax({
            type: 'GET',
            
			url:'http://localhost:50086/api/Clientes/'+localStorage.getItem('RUC')+'',
			contentType: 'application/json',
			success: function(response) {
				console.log(response);
				$.each(response, function(i, cliente){
					console.log(cliente);
                    $dato_c.append('\
                        <div class="Formulario-Content">\
                            <label class="Formulario-Label" for="name">'+labels[aux]+' </label>\
                            <label class="Formulario-Label-normal" for="name">'+cliente+'</label>\
                        </div>\
                    ');
                    aux += 1
				});
			},
			
        });
	
});


$(document).ready(function(){
    $('#boton_voler').click(function(){
        
            localStorage.setItem('RUC','');
            document.getElementById("boton_voler").href = "Buscar-Cliente.html";
       
    })
});

$(document).ready(function(){
    $('#boton_producto').click(function(){
            document.getElementById("boton_producto").href = "HistorialCompras.html";
    })
});