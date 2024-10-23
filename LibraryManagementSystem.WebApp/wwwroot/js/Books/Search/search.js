function goDetail(id, title) {

    var friendlyTitle = title.replace(/\s+/g, '-').toLowerCase();
    var url = `/books/detail/${id}/${friendlyTitle}`;
    window.location.href = url;
}

$('#headerSearch').on('input', function () {

    $('.spinnerSearch').addClass('d-block');
    $('.spinnerSearch').removeClass('d-none');
    var searchText = $(this).val();
    console.log(searchText)
    if (searchText.length > 0) {

        $.ajax({
            url: '/Books/SearchBooks',
            method: 'Post',
            data: { searchValue: searchText },
            success: function (response) {
                var books = response.data;
                console.log(books)
                $('#bookSearchResult').empty();

                if (response.isValid && response.data.length > 0) {
                    $('.spinnerSearch').addClass('d-none');
                    $('.spinnerSearch').removeClass('d-block');

                    $.each(books, function (index, book) {

                        $("#bookSearchResult").append(
                            `
                               <div class="card mb-3">
                                    <div class="row g-0">
                                        <div class="col-md-4">
                                            <img style=" height: 300px;" src="/img/${book.imageUrl}" class="img-fluid rounded-start" alt="...">
                                        </div>
                                        <div class="col-md-8">
                                            <div class="card-body">
                                                <a href="javascript:void(0);" onclick="goDetail(${book.id}, '${book.title}')" class="card-text ms-2 mb-1"><h5 class="card-title">${book.title}</h5></a>
                                                
                                                <div class="d-flex align-items-center mt-3">
                                                    <h5 class="card-title">Yazar:</h5>
                                                    <a asp-controller="Authors" asp-action="Detail" asp-route-id="2" class="card-text ms-2 mb-1">${book.author.name}</a>
                                                </div>

                                                <div class="d-flex align-items-center mt-3">
                                                    <h5 class="card-title">Yayin Yili :</h5>
                                                    <p class="card-text ms-2 mb-1">${book.publicationYear}</p>
                                                </div>

                                                <div class="d-flex align-items-center mt-3">
                                                    <h5 class="card-title">ISBN No :</h5>
                                                    <p class="card-text ms-2 mb-1">${book.isbn}</p>
                                                </div>

                                                <div class="d-flex align-items-center mt-3">
                                                    <h5 class="card-title">Tur :</h5>
                                                    <p class="card-text ms-2 mb-1">${book.genre}</p>
                                                </div>

                                                <div class="d-flex align-items-center mt-3">
                                                    <h5 class="card-title">Yayinci :</h5>
                                                    <p class="card-text ms-2 mb-1">${book.publisher}</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                            </div>
                            `);
                    });
                } else {

                    $('.spinnerSearch').addClass('d-none');
                    $('.spinnerSearch').removeClass('d-block');
                    $('#bookSearchResult').empty();
                    $('#bookSearchResult').append('<div class="movie"><h5 class="card-title">Sonuc Bulunamadi</h5></div>');
                }
            },
            error: function (xhr, status, error) {
            }
        });
    } else {
        $('.spinnerSearch').addClass('d-none');
        $('.spinnerSearch').removeClass('d-block');
        $('#bookSearchResult').empty();
    }
});