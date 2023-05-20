﻿namespace CardValidator;

internal record CardInfo
{
    public List<CardConfiguration> Configurations { get; init; } = new();
    public bool SkipLuhn { get; init; }
}