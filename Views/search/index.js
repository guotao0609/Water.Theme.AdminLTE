(function ($) {

    $(function () {
        var l = abp.localization.getResource('Joke');
        var dataTable = $('#Auditing').DataTable(abp.libs.datatables.normalizeConfiguration({
            class: 'details-control',
            processing: true,
            serverSide: true,
            paging: true,
            searching: false,
            autoWidth: false,
            scrollCollapse: true,
            order: [[2, "desc"]],
            ajax: abp.libs.datatables.createAjax(myAbp.auditing.auditLog.getList, function () {
                var UserName = $("#UserName").val();
                var HttpStatusCode = $("#HttpStatusCode").val();
                var HttpMethod = $("#HttpMethod").val();
                var model = {
                    httpMethod: HttpMethod,
                    userName: UserName,
                    httpStatusCode: HttpStatusCode,
                    startTime: null,
                    endTime: null,
                    url: null,
                    applicationName: null,
                    correlationId: null,
                    maxExecutionDuration: null,
                    minExecutionDuration: null,
                    hasException: null
                    //includeDetails: null
                };
                return model;
            }),
            columnDefs: [
                {
                    "class": 'details-control',
                    "orderable": false,
                    "data": null,
                    "defaultContent": ''
                },
                { data: "userName", "width": "15%" },
                //{ data: "tenantName" },
                { data: "executionTime", "width": "18%" },
                { data: "executionDuration", "width": "12%" },
                { data: "clientIpAddress", "width": "12%" },
                { data: "httpStatusCode", "width": "18%" },
                { data: "httpMethod", "width": "18%" },
                { data: "url"}
                //{ data: "browserInfo" }
            ]
        }));

        $('#search').click(function (e) {
            e.preventDefault();
            dataTable.ajax.reload();
        });

        // Add event listener for opening and closing details
        $('#Auditing tbody').on('click', 'td.details-control', function () {
            var tr = $(this).closest('tr');
            var row = dataTable.row(tr);
            if (row.child.isShown()) {
                row.child.hide();
                tr.removeClass('shown');
            }
            else {
                row.child(detail(row.data())).show();
                tr.addClass('shown');
            }
        });
        function detail(d) {
            var str = '';
            if (d.actions.length > 0)
            {
                str = str + '<table width="100%">' +
                    '<thead><tr><th>服务名</th><th >方法名</th><th>参数</th><th>执行时间</th><th>时长</th></tr></thead>'
                    +' <tbody class="ivu-table-tbody">';
                for (var i = 0; i < d.actions.length; i++) {
                    str = str + '<tr>' +
                        '<td width="15%">' + d.actions[i].serviceName + '</td>' +
                        '<td width="10%">' + d.actions[i].methodName + '</td>' +
                        '<td width="50%">' + d.actions[i].parameters + '</td>' +
                        '<td width="15%">' + d.actions[i].executionTime + '</td>' +
                        '<td width="10%">' + d.actions[i].executionDuration + '</td>' +
                        '</tr>';
                }
                str = str + '</tbody></table>';
            }
            return str;
        }
    });


})(jQuery);
