<%@ Page Title="Artist Search"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="CaiAptitudeAssessment.Task2._Default"
    Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron jumbotron-artist-search">
        <h1 class="display-4"><i class="fal fa-user-music"></i>Artist Search</h1>
        <p class="lead">Find albums by your favorate artists and more</p>
    </div>

    <!-- Search field -->
    <div class="row">
        <div class="col-12">
            <div class="input-group mb-3">
                <asp:TextBox ID="ArtistSearchInputTextBox" CssClass="form-control" placeholder="Artist's Name" runat="server"></asp:TextBox>
                <div class="input-group-append">
                    <asp:Button ID="ArtistSearchSubmitButton" OnClick="OnSearchArtist" CssClass="btn btn-outline-secondary" runat="server" Text="Search" />
                </div>
            </div>
        </div>
    </div>

    <!-- Search Results -->
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="SearchResultsGridView" CssClass="table" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Album Name" DataField="AlbumName" />
                    <asp:TemplateField HeaderText="Cover">
                        <ItemTemplate>
                            <img src='<%# Eval("AlbumCoverUrl") %>' class="img-fluid img-album-art" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Artist Name" DataField="ArtistName" />
                    <asp:BoundField HeaderText="Release Date" DataField="ReleaseDate" />
                    <asp:BoundField HeaderText="Tracks" DataField="NumberOfTracks" />
                    <asp:BoundField HeaderText="Popularity" DataField="Popularity" />
                </Columns>
            </asp:GridView>
            <div id="NotFoundAlertDiv" runat="server" class="alert alert-warning" role="alert">
                <i class="fal fa-music-slash"></i> Hmm, it looks like we were unable to find the artist detail you were looking for. Please try your search again.
            </div>
            <div id="ErrorDiv" runat="server" class="alert alert-danger" role="alert">
                <i class="fad fa-bug"></i> Oops, it looks like we ran into an error while attempting to process your request. Please try again with different search terms.
            </div>
        </div>
    </div>

</asp:Content>
