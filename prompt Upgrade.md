Prompt utilizado:

"Resume el siguiente texto priorizando fechas y cláusulas clave. Estructura el resumen indicando primero la razón del problema, luego su aplicación, la consecuencia y finalmente el clausulado necesario para hacer efectiva la cláusula. Mantén el resumen corto y preciso."

“Resume el siguiente texto priorizando fechas, plazos y cláusulas clave. Organiza el resumen en los siguientes apartados: (1) Razón del problema, (2) Aplicación, (3) Consecuencias y (4) Clausulado necesario. Usa un lenguaje claro y preciso, destacando las condiciones y términos esenciales”"Adicionalmente suministra un JSON con cada uno de los valores 1,2,3,4".

¿Qué mejoras hiciste y por qué?

El prompt debía establecer el ámbito del caso, es decir, interpretar el contexto en el que se aplicará el clausulado del seguro para facilitar su pronta interpretación y evitar información irrelevante. En primer lugar, debía estructurar lógicamente el caso y evaluar la consecuencia principal, es decir, el problema central que se busca resolver a través del seguro.

Una vez determinada la consecuencia, el prompt debía analizar el estado actual del caso y su ámbito de aplicación, identificando las condiciones en las que opera el seguro y su alcance. Posteriormente, en el apartado de "Consecuencia", debía definir qué ocurre si no se cumple adecuadamente con los requisitos del seguro, estableciendo los efectos de un posible incumplimiento.

Finalmente, el prompt debía determinar la cláusula aplicable según el caso concreto, indicando si el seguro cubre o no la situación y cuál es el deber de actuación del consultante para hacer valer sus derechos o cumplir con sus obligaciones.

Cómo tu versión evita respuestas irrelevantes o Ejemplo comparativo entre el prompt original y tu versión mejorada:

Prompt Original:

"En caso de revocación de la póliza o modificaciones de cualquiera de las condiciones generales o particulares del seguro por parte de la Aseguradora, Tomador o Asegurado, Seguros Sura se compromete a dar aviso a BANCO, por escrito y con una antelación no menor a 30 días a la fecha en que surtirá efecto el hecho. \[...\]"

Problemas del Prompt Original:

1.Falta de estructura lógica: No establece claramente cómo organizar la información clave.

2.No enfatiza la interpretación del caso: No especifica cómo distinguir entre la aplicación y las consecuencias de las cláusulas.

3.Puede generar respuestas extensas e imprecisas: No prioriza fechas, plazos ni cláusulas clave.

4.No evita información irrelevante: Puede incluir detalles secundarios sin distinguir lo esencial.

\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_\_

Prompt Mejorado:

"Resume el siguiente texto priorizando fechas, plazos y cláusulas clave. Organiza el resumen en los siguientes apartados: (1) Razón del problema, (2) Aplicación, (3) Consecuencias y (4) Clausulado necesario. Usa un lenguaje claro y preciso, destacando las condiciones y términos esenciales."

Mejoras Implementadas:

1.Claridad estructural: Define una organización lógica con secciones específicas (razón, aplicación, consecuencias y clausulado).

2.Foco en elementos esenciales: Destaca fechas, plazos y cláusulas clave, evitando información secundaria.

3.Evita respuestas irrelevantes: Obliga al modelo a centrarse en los aspectos críticos, reduciendo detalles innecesarios.

4.Mayor precisión en la interpretación del caso: Ayuda a extraer conclusiones claras sobre qué hacer en cada escenario.

{

"razon\_del\_problema": "Explicación breve del problema",

"aplicacion": "Descripción de cómo se aplican las normas o condiciones",

"consecuencias": "Efectos legales, financieros o contractuales",

"clausulado\_necesario": \[

"Cláusula clave 1",

"Cláusula clave 2",

"Cláusula clave 3"

\]

}

\-------------------------------------------

Respuesta con el prompt original (usado gpt 4o)

Seguros Sura notificará al banco con al menos 30 días de anticipación sobre cambios o revocaciones en la póliza. El asegurado debe reportar siniestros dentro de los 30 días siguientes a su conocimiento. La póliza cubre fallecimiento por cualquier causa y discapacidad total y permanente, incluyendo eventos como homicidio, suicidio, terrorismo y embriaguez. Su vigencia inicia a las 24:00 del día de expedición. El pago es anual por cobro bancario, y puede ser cedida en caso de titularización de cartera. Las exclusiones están en el clausulado del seguro.

Respuesta con prompt optimizado

Resumen estructurado:

Razón del problema:

La póliza de seguro puede ser revocada, modificada o terminada automáticamente por mora en el pago de la prima.

Aplicación:

Seguros Sura debe notificar por escrito al banco con al menos 30 días de antelación en caso de cambios o revocación de la póliza.

En caso de siniestro, el asegurado o beneficiario debe informar a la aseguradora dentro de los 30 días siguientes a su conocimiento.

Seguros Sura debe avisar al banco dentro de los 10 días hábiles siguientes al reporte del siniestro.

Si la póliza termina automáticamente por mora, se notificará al beneficiario oneroso con 30 días de antelación.

Consecuencias:

La póliza cubre fallecimiento por cualquier causa desde el inicio, con un valor asegurado de $98.500.000.

También cubre incapacidad total y permanente desde el inicio de vigencia, siempre que implique la pérdida del 50% o más de la capacidad laboral.

La vigencia del seguro comienza a las 24:00 del día de expedición.

Puede ser cedida en caso de titularización de cartera.

El pago es anual por cobro bancario.

Clausulado necesario:

Las exclusiones generales están en el clausulado del seguro contratado.

La edad máxima de permanencia se rige por el clausulado.

Según la Circular Externa 028 de 2019, la entidad financiera puede asumir el pago de la prima para evitar la terminación automática.

{

"1. Razón del problema": "La póliza puede ser revocada, modificada o terminada automáticamente por mora en el pago de la prima.",

"2. Aplicación": {

"Notificación al banco": "30 días de antelación en caso de cambios o revocación.",

"Reporte de siniestro": "Dentro de los 30 días siguientes al conocimiento del asegurado o beneficiario.",

"Aviso al banco": "Seguros Sura debe notificar en 10 días hábiles tras el reporte del siniestro.",

"Terminación automática por mora": "Aviso al beneficiario oneroso con 30 días de antelación."

},

"3. Consecuencias": {

"Cobertura por fallecimiento": "$98.500.000 desde el inicio.",

"Cobertura por incapacidad": "Desde el inicio, si hay pérdida del 50% o más de capacidad laboral.",

"Inicio de vigencia": "A las 24:00 del día de expedición.",

"Cesión de póliza": "Permitida en caso de titularización de cartera.",

"Forma de pago": "Anual por cobro bancario."

},

"4. Clausulado necesario": {

"Exclusiones generales": "En el clausulado del seguro contratado.",

"Edad máxima de permanencia": "Según el clausulado.",

"Circular Externa 028 de 2019": "Permite a la entidad financiera pagar la prima para evitar terminación automática."

}

}