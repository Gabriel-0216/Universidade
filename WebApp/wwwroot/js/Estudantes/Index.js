$(document).ready(function() {
    $('.table').dataTable();
    
  
});

function verificarRemover(estudanteId){
    console.log(estudanteId);
    Swal.fire({
        title: 'Tem certeza que deseja remover?',
        text: "Não será possível recuperar esse registro",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: 'Cancelar',
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Apagar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({type: 'POST',
                url: window.location.origin + `/Estudante/Remover?estudanteId=${estudanteId}`, success: function(result){
                if(result.success){
                    Swal.fire(
                        'Removido',
                        'O registro foi removido.',
                        'success'
                    )
                }
                else{
                    Swal.fire(
                        'Ocorreu um erro',
                        'O registro não foi removido.',
                        'error'
                    )
                }
                }})
        }
    })
}