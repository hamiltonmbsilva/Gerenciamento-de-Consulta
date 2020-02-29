import { http } from "./config.js";

export default {
    listarAgendamentos: () => {
        return http.get("/Agendamento");
    },

    salvar: agendamento => {
        return http.post("/Agendamento", agendamento);
    },      
    
    excluirAgendamento: id =>{
        return http.delete("/Agendamento/"+id);
    },
    
    alterarAgendamento: agendamento =>{
        var url = `/Agendamento/${agendamento.IdAgendamento}`;
        return http.put(url, agendamento);
    },
    
    buscarAgendamentoDoDia: dia =>{
        return http.get("/Agendamento/"+dia);
    },

    busvarAgendamentoPeriodoPlano: periodo =>{
        return http.get("/Agendamento/"+periodo);
    }

};