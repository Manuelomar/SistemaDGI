import { StatusType } from '../model/enums/StatusType';
import { Taxpayer } from '../model/taxpayer';
import './Table.scss'; // Importa el archivo de estilos CSS
import { Link } from 'react-router-dom';

interface TableProps {
  taxpayers: Taxpayer[];
}

const Table:React.FC<TableProps> =({taxpayers })=> {
  return (
    <table  className="tabla">
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Cedula</th>
          <th>tipo</th>
          <th>Status</th>
        </tr>
      </thead>
      <tbody>
        {
        
          taxpayers.map((taxpayer, index) =>(
            <tr  key={index}>
              <td>
              <Link to={`/taxpayer/${taxpayer.id}`}>{taxpayer.Nombre}</Link>
              </td>
              <td >{taxpayer.RncCedula}</td>
              <td>{taxpayer.Tipo}</td>
              <td>{StatusType[taxpayer.Estatus]}</td>
            </tr>
          ))
         
        }
      
      </tbody>
    </table>
  );
}
export default Table


