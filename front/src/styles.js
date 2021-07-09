import { StyleSheet } from '@react-pdf/renderer';
const borderColor = '#90e5fc'

const styles = StyleSheet.create({
    document: {
      width: '100%',
      height: '100% !important'
    },  
    table:{ 
      textAlign: 'center',
      
    },   
    header:{ 
      textAlign: 'center',
      margin: 20
      
    }, 
    headertable:{ 
  
      flexDirection: 'row',   
      fontSize: 12,  
      marginLeft: 70 
      
    },
    page: {  
      backgroundColor: '#FFFFFF',
      width: '100%',
      height: '100% !important'
    },
    section: {
      width: 500,      
      height: 100,
      margin: 10,
      padding: 10    
    },
    invoiceNoContainer: {
      flexDirection: 'row',
      marginTop: 36,
      justifyContent: 'flex-end'
    },
    tableContainer: {
          flexDirection: 'row',
          flexWrap: 'wrap',
          margin: 15,
          borderWidth: 1,
          borderColor: '#bff0fd',
          fontSize: 12
    },
    container: {
      flexDirection: 'row',
      borderBottomColor: '#bff0fd',
      backgroundColor: '#bff0fd',
      borderBottomWidth: 1,
      alignItems: 'center',
      height: 24,
      textAlign: 'center',
      fontStyle: 'bold',
      flexGrow: 1,
  },
  cliente: {
      width: '20%',
      borderRightColor: borderColor,
      borderRightWidth: 1,
  },
  numconteiner: {
      width: '20%',
      borderRightColor: borderColor,
      borderRightWidth: 1,
  },
  tipomovimentacao: {
    width: '25%',
    borderRightColor: borderColor,
    borderRightWidth: 1,
  },
  categoria: {
    width: '15%',
    borderRightColor: borderColor,
    borderRightWidth: 1,
  },
  datainicio: {
    width: '15%',
    borderRightColor: borderColor,
    borderRightWidth: 1,
  },
  datafim: {
    width: '15%',
    borderRightColor: borderColor,
    borderRightWidth: 1,
  },
  row: {
    flexDirection: 'row',
    borderBottomColor: '#bff0fd',
    borderBottomWidth: 1,
    alignItems: 'center',
    height: 24,
    fontStyle: 'bold',
    fontSize: 8
  },
  clienterow: {
    width: '20%',
    textAlign: 'center',
    borderRightColor: borderColor,
    borderRightWidth: 1,
    paddingLeft: 8,
  },
  numconteinerrow: {
    width: '20%',
    borderRightColor: borderColor,
    borderRightWidth: 1,
    textAlign: 'center',
    paddingRight: 8,
  },
  tipomovimentacaorow: {
    width: '25%',
    borderRightColor: borderColor,
    borderRightWidth: 1,
    textAlign: 'center',
    paddingRight: 8,
  },
  categoriarow: {
    width: '15%',
    borderRightColor: borderColor,
    borderRightWidth: 1,
    textAlign: 'center',
    paddingRight: 8,
  },
  datainiciorow: {
    width: '15%',
    borderRightColor: borderColor,
    borderRightWidth: 1,
    textAlign: 'center',
    paddingRight: 8,
  },
  datafimrow: {
    width: '15%',
    borderRightColor: borderColor,
    
    textAlign: 'center',
    paddingRight: 8,
  },
  tableContainertotalizadores: {
    flexDirection: 'row',
    flexWrap: 'wrap',
    margin: 15,
    borderWidth: 1,
    borderColor: '#bff0fd',
    fontSize: 14
  },
    containertotalizadores: {
    flexDirection: 'row',
    borderBottomColor: '#bff0fd',
    backgroundColor: '#bff0fd',
    borderBottomWidth: 1,
    alignItems: 'center',
    height: 24,
    textAlign: 'center',
    fontStyle: 'bold',
    flexGrow: 1,
    },
    exportacao: {
        width: '30%',
        borderRightColor: borderColor,
        borderRightWidth: 1,
        textAlign: 'center',
    },
    importacao: {
        width: '30%',
        borderRightColor: borderColor,
        borderRightWidth: 1,
        textAlign: 'center',
    },
    exportacaorow: {
        width: '39%',
        borderRightColor: borderColor,
        borderRightWidth: 1,
        textAlign: 'center',
        fontSize: 14
    },
    importacaorow: {
        width: '39%',
        borderRightColor: borderColor,        
        textAlign: 'center',
        fontSize: 14
    },
    logo: {
        width: 200,
        height: 100,
        marginLeft: 20,
        marginRight: 20,
        alignSelf: 'center',
        margin: 20
    }
  });

  export default styles;