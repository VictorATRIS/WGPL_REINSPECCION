Public Module Variables
    'Variables de forma de Administracion
    Public var_adm_Usr_ID As String
    Public var_adm_Usr_NICK As String
    Public var_adm_Usr_Name As String
    Public var_adm_Planta As String
    Public var_adm_group As String
    Public var_IP_mailserver As String
    Public var_conexionSAUERP As String
    Public var_conexionERP As String
    Public var_conexionPOP As String
    Public var_conexionCTRACE As String
    Public var_conexionWO As String
    Public var_conexionSAPC As String
    Public var_conexionPOP35 As String
    Public var_conexionPOPSP As String
    Public var_conexionMPS As String
    Public var_conexionCNC As String
    Public var_conexionICS As String
    Public var_conexionTRESS As String

    Public var_RptUsr As String
    Public var_RptPwd As String
    Public var_RptKitPwd As String

    Public var_RptUsrSAU As String
    Public var_RptPwdSAU As String

    Public CCDominio As String
    Public CCUsuario As String
    Public CCPAssword As String


    '------------------------------------------------------------------------------------------------------------
    'Variable de forma de confirmacion de caja
    Public var_escaneabulto_fecha As String                 'Fecha de Escaneo
    Public var_escaneabulto_bulto As Integer                'No de bulto al que se le escanearan contenedores
    Public var_escaneabulto_troka As String                 'No de troka
    Public var_escaneabulto_CodPlanta As String                 'No de troka
    Public var_escaneabulto_cuencame As Boolean
    Public var_escaneabulto_cuencame_asn As String
    Public var_escaneabulto_array_bulto(6) As String
    Public var_escaneabulto_cont_bulto As Int32
    '------------------------------------------------------------------------------------------------------------
    'Variables de control de produccion
    Public var_ctrl_plan_bandera_errorxref As Boolean
    Public var_ctrl_etiquetas_bandera As Boolean
    Public var_ctrl_plan_revision As String
    Public var_ctrl_plan_rev_new As String
    Public var_ctrl_plan_rev_active As String
    '------------------------------------------------------------------------------------------------------------
    'Variables de atrview
    Public var_rh_atrview_empleado_no As Int32
    '------------------------------------------------------------------------------------------------------------
    'Variables de erp_kan
    Public var_kan_kit_grafica_lote As String
    Public var_kan_kit_grafica_planta As String
    Public var_kan_estatus_lote As String
    '------------------------------------------------------------------------------------------------------------
    'Variables de PTSP
    Public var_ptsp_wo As String
    '------------------------------------------------------------------------------------------------------------
    'Varuables MTTO THS
    Public var_mtto_ths_plant As String
    '------------------------------------------------------------------------------------------------------------
    'Variables AAMIS
    Public var_mtto_apli_user As String
    Public var_mtto_apli_login As String
    Public var_mtto_apli_es As String
    Public var_mtto_apli_tipolib As String
    Public var_mtto_apli_apli As String
    Public var_mtto_apli_guion As String
    Public var_mtto_apli_folio As Int32
    Public var_scrap_SU As Boolean
    '------------------------------------------------------------------------------------------------------------
    'Variables THS
    Public var_mtto_ths_revision As String
    '------------------------------------------------------------------------------------------------------------
    'Variables Contramedidas
    Public var_qa_defecto_folio As String
    Public var_qa_defect_opcion As String
    Public var_qa_defect_responsable As String
    Public var_qa_defect_contramedida As String
    Public var_qa_defect_contramedida_tipo As String
    Public var_qa_defect_contramedida_fecha As String
    Public var_qa_defect_contramedida_indice As Int32
    Public var_qa_defect_contador_PorquePaso As Int32
    Public var_qa_defect_contador_NoDetecto As Int32
    Public var_qa_defect_tipo_conexion As String

    'Variables de Configuraciones
    Public var_mat_imprime_etiquetas_carretes_term As String
End Module
