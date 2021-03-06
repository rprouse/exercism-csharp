using Xunit;


public class ComplementTest
{
    [Fact]
    public void Rna_complement_of_cytosine_is_guanine()
    {
        Assert.Equal("G", Complement.OfDna("C"));
    }

    [Fact]
    public void Rna_complement_of_guanine_is_cytosine()
    {
        Assert.Equal("C", Complement.OfDna("G"));
    }

    [Fact]
    public void Rna_complement_of_thymine_is_adenine()
    {
        Assert.Equal("A", Complement.OfDna("T"));
    }

    [Fact]
    public void Rna_complement_of_adenine_is_uracil()
    {
        Assert.Equal("U", Complement.OfDna("A"));
    }

    [Fact]
    public void Rna_complement()
    {
        Assert.Equal("UGCACCAGAAUU", Complement.OfDna("ACGTGGTCTTAA"));
    }

    [Fact]
    public void Dna_complement_of_cytosine_is_guanine()
    {
        Assert.Equal("G", Complement.OfRna("C"));
    }

    [Fact]
    public void Dna_complement_of_guanine_is_cytosine()
    {
        Assert.Equal("C", Complement.OfRna("G"));
    }

    [Fact]
    public void Dna_complement_of_uracil_is_adenine()
    {
        Assert.Equal("A", Complement.OfRna("U"));
    }

    [Fact]
    public void Dna_complement_of_adenine_is_thymine()
    {
        Assert.Equal("T", Complement.OfRna("A"));
    }

    [Fact]
    public void Dna_complement()
    {
        Assert.Equal("ACTTGGGCTGTAC", Complement.OfRna("UGAACCCGACAUG"));
    }
}