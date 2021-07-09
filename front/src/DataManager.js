export async function GetMovimentacao() {

    let caminho = "http://localhost:6002/api/Movimentacao/agrupadas"
  
    return fetch(caminho, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'         
        }
    })
    .then((res) => {
        return res.json();
    })
    .then((data) => {
        return data;
    })
}