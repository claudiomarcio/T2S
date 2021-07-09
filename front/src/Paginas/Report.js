import React, {Fragment } from 'react';
import { PDFViewer, Document, Image, Page, Text, View } from '@react-pdf/renderer';
import dateFormat from 'dateformat';
import styles from '../styles.js'
import logo from '../logo.png'

const Report = (props) => {
      
  
  let totalExportacoes = props.data.movimentacoes ? props.data.movimentacoes.totalExportacao : 0
  let totalImportacoes = props.data.movimentacoes ? props.data.movimentacoes.totalImportacao : 0
  
  var rows = props.data.movimentacoes ? props.data.movimentacoes.movimentacoes.map((m, index) => {
    return m.map((mov,i) => {
 
      return  <View style={styles.row} key={i}>
                <Text style={styles.clienterow}>{mov.conteiner.cliente.nome}</Text>
                <Text style={styles.numconteinerrow}>{mov.conteiner.numero}</Text>
                <Text style={styles.tipomovimentacaorow}>{mov.tipoMovimentacao.descricao}</Text>
                <Text style={styles.categoriarow}>{mov.conteiner.categoria.descricao}</Text>
                <Text style={styles.datainiciorow}>{ dateFormat(mov.dataHoraInicio,"dd/mm/yyyy hh:mm")}</Text>
                <Text style={styles.datafimrow}>{dateFormat(mov.dataHoraFim,"dd/mm/yyyy hh:mm")}</Text>
              </View>
    })

  }) : []


    const LinhasTabela = () => {
            
      return (<Fragment>{rows}</Fragment> )
    };   
   
  return (
    <div>
     <PDFViewer style={styles.document} height={745} >
            <Document >
          <Page size="A4" style={styles.page}>
          <Image style={styles.logo} src={logo} />
             <View style={styles.header}>
              <Text>T2S - Movimentações</Text>
            </View>            
            <View style={styles.tableContainer}>
              <View style={styles.container}>
                  <Text style={styles.cliente}>Cliente</Text>
                  <Text style={styles.numconteiner}>Num. Conteiner</Text>
                  <Text style={styles.tipomovimentacao}>Tipo de Movimentação</Text>
                  <Text style={styles.categoria}>Categoria</Text>
                  <Text style={styles.datainicio}>Data Inicio</Text>
                  <Text style={styles.datafim}>Data Fim</Text>
              </View>
              <LinhasTabela/>            
            </View>    
            <View style={styles.tableContainertotalizadores}>
              <View style={styles.containertotalizadores}>
                  <Text style={styles.exportacao}>Qtd Exportações</Text>
                  <Text style={styles.importacao}>Qtd Importações</Text>
              </View> 
              <Fragment>
                <View style={styles.row}>
                <Text style={styles.exportacaorow}>{totalExportacoes}</Text>
                <Text style={styles.importacaorow}>{totalImportacoes}</Text>
              </View>
            </Fragment>                 
          </View>                                                 
          </Page>
        </Document>
      </PDFViewer>                                                                               
    </div>
    )            
}

export default Report