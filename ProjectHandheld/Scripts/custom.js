/**
 *
 * You can write your JS code here, DO NOT touch the default style file
 * because it will make it harder for you to update.
 * 
 */

$(document).ready(function () {
    $('.dataTable').DataTable();
    $('[name="dtTable"]').DataTable();
    $('[data-toggle="tooltip"]').tooltip();

    //change active clas sidebar menu
    var $link = window.location.pathname + window.location.search;
    console.log($link);
    $(".menu-link").removeClass("active");
    $("[href='" + $link + "']").addClass("active");
    $("[href='" + $link + "']").parent().parent().parent().children(":first").addClass("active");
    $("[href='" + $link + "']").parent().parent().parent().parent().parent().children(":first").addClass("active");


    //SHOW HIDE OPTION REVISI SCANNER
    ShowHideRevScan();
    function ShowHideRevScan() {
        var $zona = $("#zonaRevScan");
        var $plu = $("#pluRevScan");
        var $station = $("#stationRevScan");
        var $sampai = $(".sampaiRevScan");
        var $enddate = $("#enddate");
        $zona.hide();
        $plu.hide();
        $station.hide();
        $("#menuRevScan").change(function () {
            $(this).find("option:selected").each(function () {
                var optionValue = $(this).attr("value");
                if (optionValue == "all") {
                    $zona.hide();
                    $plu.hide();
                    $station.hide();
                    $sampai.show();
                    $enddate.attr("required", true);
                }
                else if (optionValue == "zona") {
                    $zona.show();
                    $plu.hide();
                    $station.hide();
                    $sampai.show();
                    $enddate.attr("required", true);
                }
                else if (optionValue == "plu") {
                    $zona.hide();
                    $plu.show();
                    $station.hide();
                    $sampai.show();
                    $enddate.attr("required", true);
                }
                else if (optionValue == "day") {
                    $zona.show();
                    $plu.hide();
                    $station.show();
                    $sampai.hide();
                    $enddate.removeAttr("required");
                }
            });
        }).change();
    }

    //SHOW HIDE REKAP HASIL PICKING
    ShowHideHasilPicking();
    function ShowHideHasilPicking() {
        var $tgl = $("#hasilPickingByTgl");
        var $npb = $("#hasilPickingByNPB");
        var $item = $("#tbitem");
        var $zona = $("#zonaHasilPicking");
        var $station = $("#stationHasilPicking");
        var $dateInput = $("#startdate");
        var $nonpb = $("#no_npb");
        $tgl.hide();
        $npb.hide();
        $item.hide();
        $zona.show();
        $station.show();
        $dateInput.attr("required", true);
        $("#ddlRekapBy").change(function () {
            $(this).find("option:selected").each(function () {
                var optionValue = $(this).attr("value");
                if (optionValue == "tgl") {
                    $tgl.show();
                    $npb.hide();
                    $nonpb.removeAttr("required");
                    $dateInput.attr("required", true);
                    $nonpb.val("");
                }
                else if (optionValue == "npb") {
                    $tgl.hide();
                    $npb.show();
                    $nonpb.attr("required", true);
                    $dateInput.removeAttr("required");
                    $dateInput.val("");
                }
            });
        }).change();

        $("#ddlFilterBy").change(function () {
            $(this).find("option:selected").each(function () {
                var optionValue = $(this).attr("value");
                if (optionValue == "planogram") {
                    $zona.show();
                    $station.show();
                    $item.hide();
                    $("#tbitem").removeAttr("required");
                }
                else if (optionValue == "item") {
                    $zona.hide();
                    $station.hide();
                    $item.show();
                    $("#tbitem").attr("required", true);
                }
            });
        }).change();
    }

    //SHOW HIDE POSISI MUTASI STOK HARIAN NEW
    ShowHidePosMutStokHarNew();
    function ShowHidePosMutStokHarNew() {
        var plu = $("#pluMutasiStokHarNew");
        var divisi = $("#divisiMutasiStokHarNew");
        var dept2 = $("#departemenMutasiStokHarNew2");
        var dept1 = $("#departemenMutasiStokHarNew1");
        var kategori = $("#kategoriMutasiStokHarNew");
        var supplier = $("#supplierMutasiStokHarNew");
        var lantai = $("#lantaiMutasiStokHarNew");
        var rincian = $("#perincianMutasiStokHarNew");
        plu.hide();
        divisi.hide();
        dept1.hide();
        dept2.hide();
        kategori.hide();
        supplier.hide();
        lantai.hide();
        rincian.hide();

        $("#ddlCetak").change(function () {
            $(this).find("option:selected").each(function () {
                var cetak = $(this).attr("value");
                if (cetak == "item") {
                    plu.show();
                    divisi.hide();
                    dept1.hide();
                    dept2.hide();
                    kategori.hide();
                    supplier.hide();
                    lantai.hide();
                    rincian.hide();
                } else if (cetak == "divisi") {
                    plu.hide();
                    divisi.show();
                    dept1.hide();
                    dept2.hide();
                    kategori.hide();
                    supplier.hide();
                    lantai.hide();
                    rincian.show();
                } else if (cetak == "lantai") {
                    plu.hide();
                    divisi.hide();
                    dept1.hide();
                    dept2.hide();
                    kategori.hide();
                    supplier.hide();
                    lantai.show();
                    rincian.show();
                } else if (cetak == "supplier") {
                    plu.hide();
                    divisi.hide();
                    dept1.hide();
                    dept2.hide();
                    kategori.hide();
                    supplier.show();
                    lantai.hide();
                    rincian.show();
                } else if (cetak == "departemen") {
                    plu.hide();
                    divisi.hide();
                    dept1.hide();
                    dept2.show();
                    kategori.hide();
                    supplier.hide();
                    lantai.hide();
                    rincian.show();
                } else if (cetak == "kategori") {
                    plu.hide();
                    divisi.hide();
                    dept1.show();
                    dept2.hide();
                    kategori.show();
                    supplier.hide();
                    lantai.hide();
                    rincian.show();
                }
            });
        }).change();
    }

    //SHOW HIDE CETAK LAPORAN NKL DC
    ShowHideCtkLapNKLDC();
    function ShowHideCtkLapNKLDC() {
        var $date = $("#PeriodeNKLDC");
        var $item = $("#ItemNKLDC");
        var $divisi = $("#DivisiNKLDC");
        var $line = $("#LineNKLDC");
        var $detail = $("#CBDetailNKLDC");
        $item.hide();
        $divisi.hide();
        $line.hide();
        $detail.hide();
        $("input:radio[name=rbType]").change(function () {
            var $value = $(this).val();
            if ($value == "date") {
                $date.show();
                $item.hide();
                $divisi.hide();
                $line.hide();
                $detail.hide();
            }
            else if ($value == "line") {
                $date.show();
                $item.hide();
                $divisi.hide();
                $line.show();
                $detail.show();
            }
            else if ($value == "divisi") {
                $date.show();
                $item.hide();
                $divisi.show();
                $line.hide();
                $detail.show();
            }
            else if ($value == "item") {
                $date.show();
                $item.show();
                $divisi.hide();
                $line.hide();
                $detail.hide();
            }
        });
    }

    //Laporan Container/Bronjong Tertinggal
    $("#alertContBronj").hide();
});

