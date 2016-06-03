$.extend($.fn.dataTable.defaults, {
    "searching": false,
    "processing": false,
    "lengthMenu": [10, 20, 50, 100],
    "pageLength": 50,
    "pagingType": "full_numbers",
    "dom": "frtipl",
    "language": {
        "emptyTable": "No data available in table",
        "info" : "<strong>Showing</strong> _START_ to _END_ of _TOTAL_ entries",
        "paginate": {
            "first": " << ",
            "last": " >> ",
            "next": " > ",
            "previous" : " < "
        }
    }
} );