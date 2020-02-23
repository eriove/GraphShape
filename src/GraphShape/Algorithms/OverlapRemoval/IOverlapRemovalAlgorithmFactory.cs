﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace GraphShape.Algorithms.OverlapRemoval
{
    /// <summary>
    /// Represents a factory of overlap removal algorithms.
    /// </summary>
    /// <typeparam name="TVertex">Vertex type.</typeparam>
    public interface IOverlapRemovalAlgorithmFactory<TVertex>
    {
        /// <summary>
        /// The set of available algorithms.
        /// </summary>
        [NotNull, ItemNotNull]
        IEnumerable<string> AlgorithmTypes { get; }

        /// <summary>
        /// Creates an algorithm corresponding to given <paramref name="algorithmType"/>,
        /// <paramref name="context"/> and <paramref name="parameters"/>.
        /// </summary>
        /// <param name="algorithmType">Algorithm type.</param>
        /// <param name="context">Creation context.</param>
        /// <param name="parameters">Algorithm parameters.</param>
        /// <returns>Created algorithm.</returns>
        [Pure]
        IOverlapRemovalAlgorithm<TVertex> CreateAlgorithm(
            [NotNull] string algorithmType,
            [NotNull] IOverlapRemovalContext<TVertex> context,
            [NotNull] IOverlapRemovalParameters parameters);

        /// <summary>
        /// Creates algorithm parameters for an algorithm of given <paramref name="algorithmType"/>
        /// and <paramref name="oldParameters"/>.
        /// </summary>
        /// <param name="algorithmType">Algorithm type.</param>
        /// <param name="oldParameters">Old parameters.</param>
        /// <returns>New algorithm parameters.</returns>
        [Pure]
        IOverlapRemovalParameters CreateParameters([NotNull] string algorithmType, [CanBeNull] IOverlapRemovalParameters oldParameters);

        /// <summary>
        /// Checks if the given <paramref name="algorithmType"/> is a valid one.
        /// </summary>
        /// <param name="algorithmType">Algorithm type.</param>
        /// <returns>True if the algorithm type is valid, false otherwise.</returns>
        [Pure]
        bool IsValidAlgorithm([CanBeNull] string algorithmType);

        /// <summary>
        /// Gets the algorithm type from a given <paramref name="algorithm"/>.
        /// </summary>
        /// <param name="algorithm">Algorithm to get its type.</param>
        /// <returns>Algorithm type.</returns>
        [Pure]
        string GetAlgorithmType([NotNull] IOverlapRemovalAlgorithm<TVertex> algorithm);
    }
}