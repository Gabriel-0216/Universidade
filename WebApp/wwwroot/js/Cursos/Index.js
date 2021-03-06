$(document).ready(function() {
    $('.table').dataTable();
});

function remover(cursoId){
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
                url: window.location.origin + `/Curso/Remover?cursoId=${cursoId}`, success: function(result){
                    if(result.success){
                        Swal.fire(
                            'Removido',
                            'O registro foi removido.',
                            'success'
                        )
                        setTimeout(function(){
                            window.location.reload();
                        }, 5000);
                    }
                    else{
                        Swal.fire(
                            'Ocorreu um erro',
                            `O registro não foi removido: ${result.erros}`,
                            'error'
                        )
                    }
                }})
        }
    })
}